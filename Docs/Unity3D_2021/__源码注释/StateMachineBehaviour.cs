#region Assembly UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using UnityEngine.Animations;
using UnityEngine.Scripting;

namespace UnityEngine;

//
// Summary:
//     StateMachineBehaviour is a component that can be added to a state machine state.
//     It's the base class every script on a state derives from.
[RequiredByNativeCode]
public abstract class StateMachineBehaviour : ScriptableObject
{
    public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public virtual void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public virtual void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public virtual void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public virtual void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    //
    // Summary:
    //     Called on the first Update frame when making a transition to a state machine.
    //     This is not called when making a transition into a state machine sub-state.
    //
    // Parameters:
    //   animator:
    //     The Animator playing this state machine.
    //
    //   stateMachinePathHash:
    //     The full path hash for this state machine.
    public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
    }

    //
    // Summary:
    //     Called on the last Update frame when making a transition out of a StateMachine.
    //     This is not called when making a transition into a StateMachine sub-state.
    //
    // Parameters:
    //   animator:
    //     The Animator playing this state machine.
    //
    //   stateMachinePathHash:
    //     The full path hash for this state machine.
    public virtual void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
    }

    public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
    }

    public virtual void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
    }

    public virtual void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
    }

    public virtual void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
    }

    public virtual void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
    }

    public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash, AnimatorControllerPlayable controller)
    {
    }

    public virtual void OnStateMachineExit(Animator animator, int stateMachinePathHash, AnimatorControllerPlayable controller)
    {
    }
}
#if false // Decompilation log
