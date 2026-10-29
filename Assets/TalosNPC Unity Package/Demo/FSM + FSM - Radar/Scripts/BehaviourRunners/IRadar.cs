using TalosNPC.StateMachines;

namespace TalosNPC.UnityToolkit.Demos
{
	public interface IRadar
	{
		public State GetBrokenState();
		public State GetWorkingState();
	}

}