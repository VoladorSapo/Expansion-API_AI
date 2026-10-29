using TalosNPC.StateMachines.StackFSMs;

namespace TalosNPC.UnityToolkit.GUIDesigner.Editor.Graphs
{
    [CustomGraphAdapter(typeof(StackFSM))]
    public class StackFSMAdapter : StateMachineAdapter
    {
        public override string IconPath => TalosNPCSettings.instance.IconPath + "Graphs/stackfsm.png";
    }
}
