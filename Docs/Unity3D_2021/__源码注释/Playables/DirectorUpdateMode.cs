#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Playables
{
    //
    // 摘要:
    //     Defines what time source is used to update a Director graph.
    public enum DirectorUpdateMode
    {

        //
        // 摘要:
        //     Update is based on DSP (Digital Sound Processing) clock. Use this for graphs
        //     that need to be synchronized with Audio.
        DSPClock = 0,

        //
        // 摘要:
        //     Update is based on Time.time. Use this for graphs that need to be synchronized
        //     on gameplay, and that need to be paused when the game is paused.
        GameTime = 1,

        //
        // 摘要:
        //     Update is based on Time.unscaledTime. Use this for graphs that need to be updated
        //     even when gameplay is paused. Example: Menus transitions need to be updated even
        //     when the game is paused.
        UnscaledGameTime = 2,
        
        //
        // 摘要:
        //     Update mode is manual. You need to manually call PlayableGraph.Evaluate with
        //     your own deltaTime. This can be useful for graphs that are completely disconnected
        //     from the rest of the game. For example, localized bullet time.
        Manual = 3
    }
}

