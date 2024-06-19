/*
 * Advanced C# messenger by Ilya Suzdalnitski. V1.0
 * 
 * Based on Rod Hyde's "CSharpMessenger" and Magnus Wolffelt's "CSharpMessenger Extended".
 * 
 * Features:
 	* Prevents a MissingReferenceException because of a reference to a destroyed message handler.
 	* Option to log all messages
 	* Extensive error detection, preventing silent bugs
 * 
 * Usage examples:
 	1. EventsModule.AddListener<GameObject>("prop collected", PropCollected);
 	   EventsModule.Broadcast<GameObject>("prop collected", prop);
       EventsModule.RemoveListener<GameObject>("prop collected", PropCollected);

 	2. EventsModule.AddListener<float>("speed changed", SpeedChanged);
 	   EventsModule.Broadcast<float>("speed changed", 0.5f);
       EventsModule.RemoveListener<float>("speed changed", SpeedChanged);

 * 
 * EventsModule cleans up its evenTable automatically upon loading of a new level.//TODO
 * 
 * Don't forget that the messages that should survive the cleanup, should be marked with EventsModule.MarkAsPermanent(string)
 * 
 */

//#define LOG_ALL_MESSAGES
//#define LOG_ADD_LISTENER
//#define LOG_BROADCAST_MESSAGE
//#define REQUIRE_LISTENER

using System;
using System.Collections.Generic;
using UnityEngine;



namespace Tools
{

    //注意这个信号是要自己管理了
    public static class EventsModule
    {


        public delegate void ECallback(object[] datas, System.Exception exception = null);
        public delegate void EVoidCallback();
        public delegate void ECallback<T>(T arg1);
        public delegate void ECallback<T, U>(T arg1, U arg2);
        public delegate void ECallback<T, U, V>(T arg1, U arg2, V arg3);
        public delegate void ECallback<T, U, V, W>(T arg1, U arg2, V arg3, W arg4);


        //---------------------------------


        #region Internal variables

//         //Disable the unused variable warning
// // #pragma warning disable 0414
//         //Ensures that the MessengerHelper will be created automatically upon start of the game.
//         static private EventsModuleHelper messengerHelper =
//             (new GameObject("MessengerHelper")).AddComponent<EventsModuleHelper>();
// // #pragma warning restore 0414

        static public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();

        //Message handlers that should never be removed, regardless of calling Cleanup
        static public List<string> permanentMessages = new List<string>();

        #endregion


        #region Helper methods

        //Marks a certain message as permanent.
        static public void MarkAsPermanent(string eventType)
        {
            permanentMessages.Add(eventType);
        }


        static public void Cleanup()
        {
            List<string> messagesToRemove = new List<string>();

            foreach (KeyValuePair<string, Delegate> pair in eventTable)
            {
                bool wasFound = false;

                foreach (string message in permanentMessages)
                {
                    if (pair.Key == message)
                    {
                        wasFound = true;
                        break;
                    }
                }

                if (!wasFound)
                    messagesToRemove.Add(pair.Key);
            }

            foreach (string message in messagesToRemove)
            {
                eventTable.Remove(message);
            }
        }

        static public void PrintEventTable()
        {
            Debug.Log("\t\t\t=== MESSENGER PrintEventTable ===");

            foreach (KeyValuePair<string, Delegate> pair in eventTable)
            {
                Debug.Log("\t\t\t" + pair.Key + "\t\t" + pair.Value);
            }

            Debug.Log("\n");
        }

        #endregion

        #region Message logging and exception throwing

        static public void OnListenerAdding(string eventType, Delegate listenerBeingAdded)
        {
            if (!eventTable.ContainsKey(eventType))
            {
                eventTable.Add(eventType, null);
            }

            Delegate d = eventTable[eventType];
            if (d != null && d.GetType() != listenerBeingAdded.GetType())
            {
                throw new ListenerException(string.Format(
                    "Attempting to add listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being added has type {2}",
                    eventType, d.GetType().Name, listenerBeingAdded.GetType().Name));
            }
        }

        static public void OnListenerRemoving(string eventType, Delegate listenerBeingRemoved)
        {
            if (eventTable.ContainsKey(eventType))
            {
                Delegate d = eventTable[eventType];

                if (d == null)
                {
                    throw new ListenerException(string.Format(
                        "Attempting to remove listener with for event type \"{0}\" but current listener is null.",
                        eventType));
                }
                else if (d.GetType() != listenerBeingRemoved.GetType())
                {
                    throw new ListenerException(string.Format(
                        "Attempting to remove listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being removed has type {2}",
                        eventType, d.GetType().Name, listenerBeingRemoved.GetType().Name));
                }
            }
        }

        static public void OnListenerRemoved(string eventType)
        {
            if (eventTable.ContainsKey(eventType))
            {
                if (eventTable[eventType] == null)
                {
                    eventTable.Remove(eventType);
                }
            }
            else
            {
                //MyLogger.LogWarning("(OnListenerRemoved error) eventType is : {0}", eventType);
                Debug.LogError( "(OnListenerRemoved error) eventType is : " + eventType ); // tpr
            }
        }

        static public void OnBroadcasting(string eventType)
        {
#if REQUIRE_LISTENER
        if (!eventTable.ContainsKey(eventType)) {
            throw new BroadcastException(string.Format("Broadcasting message \"{0}\" but no listener found. Try marking the message with Messenger.MarkAsPermanent.", eventType));
        }
#endif
        }

        static public BroadcastException CreateBroadcastSignatureException(string eventType)
        {
            return new BroadcastException(string.Format(
                "Broadcasting message \"{0}\" but listeners have a different signature than the broadcaster.",
                eventType));
        }

        public class BroadcastException : Exception
        {
            public BroadcastException(string msg)
                : base(msg)
            {
            }
        }

        public class ListenerException : Exception
        {
            public ListenerException(string msg)
                : base(msg)
            {
            }
        }

        #endregion

        #region AddListener

        static public void AddListener(int eventType, EVoidCallback handler)
        {
            AddListener(eventType.ToString(), handler);
        }

        //No parameters
        static public void AddListener(string eventType, EVoidCallback handler)
        {
            OnListenerAdding(eventType, handler);
            eventTable[eventType] = (EVoidCallback) eventTable[eventType] + handler;
        }

        static public void AddListener<T>(int eventType, ECallback<T> handler)
        {
            AddListener<T>(eventType.ToString(), handler);
        }

        //Single parameter
        static public void AddListener<T>(string eventType, ECallback<T> handler)
        {
            OnListenerAdding(eventType, handler);
            eventTable[eventType] = (ECallback<T>) eventTable[eventType] + handler;
        }

        //Two parameters
        static public void AddListener<T, U>(string eventType, ECallback<T, U> handler)
        {
            OnListenerAdding(eventType, handler);
            eventTable[eventType] = (ECallback<T, U>) eventTable[eventType] + handler;
        }

        //Three parameters
        static public void AddListener<T, U, V>(string eventType, ECallback<T, U, V> handler)
        {
            OnListenerAdding(eventType, handler);
            eventTable[eventType] = (ECallback<T, U, V>) eventTable[eventType] + handler;
        }

        #endregion

        #region RemoveListener

        static public void RemoveListener(int eventType, EVoidCallback handler)
        {
            RemoveListener(eventType.ToString(), handler);
        }

        //No parameters
        static public void RemoveListener(string eventType, EVoidCallback handler)
        {
            OnListenerRemoving(eventType, handler);
            if (eventTable.ContainsKey(eventType))
            {
                eventTable[eventType] = (EVoidCallback) eventTable[eventType] - handler;
            }
            OnListenerRemoved(eventType);
        }

        static public void RemoveListener<T>(int eventType, ECallback<T> handler)
        {
            RemoveListener<T>(eventType.ToString(), handler);
        }

        //Single parameter
        static public void RemoveListener<T>(string eventType, ECallback<T> handler)
        {
            OnListenerRemoving(eventType, handler);
            if (eventTable.ContainsKey(eventType))
            {
                eventTable[eventType] = (ECallback<T>) eventTable[eventType] - handler;
            }
            
            OnListenerRemoved(eventType);
        }

        //Two parameters
        static public void RemoveListener<T, U>(string eventType, ECallback<T, U> handler)
        {
            OnListenerRemoving(eventType, handler);
            if (eventTable.ContainsKey(eventType))
            {
                eventTable[eventType] = (ECallback<T, U>) eventTable[eventType] - handler;
            }
            OnListenerRemoved(eventType);
        }

        //Three parameters
        static public void RemoveListener<T, U, V>(string eventType, ECallback<T, U, V> handler)
        {
            OnListenerRemoving(eventType, handler);
            if (eventTable.ContainsKey(eventType))
            {
                eventTable[eventType] = (ECallback<T, U, V>) eventTable[eventType] - handler;
            }
            OnListenerRemoved(eventType);
        }

        #endregion

        #region Broadcast

        static public void Broadcast(int eventType)
        {
            Broadcast(eventType.ToString());
        }

        //No parameters
        static public void Broadcast(string eventType)
        {
            OnBroadcasting(eventType);

            Delegate d;
            if (eventTable.TryGetValue(eventType, out d))
            {
                if (d is EVoidCallback callback)
                {
                    callback.Invoke();
                }
                else
                {
                    throw CreateBroadcastSignatureException(eventType);
                }
            }
        }

        static public void Broadcast<T>(int eventType, T arg1)
        {
            Broadcast<T>(eventType.ToString(), arg1);
        }

        //Single parameter
        static public void Broadcast<T>(string eventType, T arg1)
        {
            OnBroadcasting(eventType);

            Delegate d;
            if (eventTable.TryGetValue(eventType, out d))
            {
                if (d is ECallback<T> callback)
                {
                    callback(arg1);
                }
                else
                {
                    throw CreateBroadcastSignatureException(eventType);
                }
            }

            //else {
            //    Debug.Log(" this ? " + eventType);
            //}
        }

        //Two parameters
        static public void Broadcast<T, U>(string eventType, T arg1, U arg2)
        {
            OnBroadcasting(eventType);

            Delegate d;
            if (eventTable.TryGetValue(eventType, out d))
            {
                if (d is ECallback<T, U> callback)
                {
                    callback(arg1, arg2);
                }
                else
                {
                    throw CreateBroadcastSignatureException(eventType);
                }
            }
        }

        //Three parameters
        static public void Broadcast<T, U, V>(string eventType, T arg1, U arg2, V arg3)
        {
            OnBroadcasting(eventType);

            Delegate d;
            if (eventTable.TryGetValue(eventType, out d))
            {
                if (d is ECallback<T, U, V> callback)
                {
                    callback(arg1, arg2, arg3);
                }
                else
                {
                    throw CreateBroadcastSignatureException(eventType);
                }
            }
        }

        #endregion
    }

//This manager will ensure that the messenger's eventTable will be cleaned up upon loading of a new level.
    // public sealed class EventsModuleHelper : MonoBehaviour
    // {
    //     void Awake()
    //     {
    //         DontDestroyOnLoad(gameObject);
    //     }
    //
    // }
}