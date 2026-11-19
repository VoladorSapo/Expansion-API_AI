using System;

namespace TalosNPC.StateMachines
{
    using Core;

    /// <summary>
    /// The base node for fsm graphs.
    /// </summary>
    public abstract class FSMNode : Node
    {
        public override Type GraphType => typeof(FSM);
    }
}
