using System;

namespace TalosNPC.BehaviourTrees
{
    public interface ITrueFalseBranchNode
    {
        TrueFalseBranchNode SetNodeIndexFunction(Func<bool> nodeIndexFunction);
    }
}