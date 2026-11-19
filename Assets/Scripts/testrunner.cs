using System;
using System.Collections.Generic;
using UnityEngine;
using TalosNPC.Core;
using TalosNPC.Core.Actions;
using TalosNPC.Core.Perceptions;
using TalosNPC.UnityToolkit;
using TalosNPC.StateMachines;
using TalosNPC.BehaviourTrees;

public class testrunner : BehaviourRunner
{
	
	
	protected override BehaviourGraph CreateGraph()
	{
		FSM newfsmgraph = new FSM();
		BehaviourTree newbehaviourtreegraph = new BehaviourTree();
		
		State unnamed = newfsmgraph.CreateState();
		
		State unnamed_2 = newfsmgraph.CreateState();
		
		StateTransition unnamed_1 = newfsmgraph.CreateTransition(unnamed, unnamed_2);
		
		return newfsmgraph;
	}
}
