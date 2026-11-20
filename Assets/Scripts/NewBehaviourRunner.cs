using System;
using System.Collections.Generic;
using UnityEngine;
using TalosNPC.Core;
using TalosNPC.Core.Actions;
using TalosNPC.Core.Perceptions;
using TalosNPC.UnityToolkit;
using TalosNPC.StateMachines;
using TalosNPC.BehaviourTrees;

public class NewBehaviourRunner : BehaviourRunner
{
	private PushPerception _12SFSD_gokulegana_;
	
	
	protected override BehaviourGraph CreateGraph()
	{
		FSM newfsmgraph = new FSM();
		BehaviourTree newbehaviourtreegraph = new BehaviourTree();
		
		ChangeTintAction unnamed_action = new ChangeTintAction();
		State unnamed = newfsmgraph.CreateState(unnamed_action);
		
		State unnamed_1 = newfsmgraph.CreateState();
		
		ChangeTintAction unnamed_2_action = new ChangeTintAction();
		State unnamed_2 = newfsmgraph.CreateState(unnamed_2_action);
		
		StateTransition Transition2 = newfsmgraph.CreateTransition(unnamed, unnamed_2, statusFlags: StatusFlags.None);
		
		StateTransition unnamed_3 = newfsmgraph.CreateTransition(unnamed_2, unnamed, statusFlags: StatusFlags.Success);
		
		SuccesFailAction Hay_Pistola__action = new SuccesFailAction();
		LeafNode Hay_Pistola_ = newbehaviourtreegraph.CreateLeafNode(Hay_Pistola__action);
		
		SuccesFailAction Coger_Pistola_action = new SuccesFailAction();
		LeafNode Coger_Pistola = newbehaviourtreegraph.CreateLeafNode(Coger_Pistola_action);
		
		SequencerNode Intentar_Pistola = newbehaviourtreegraph.CreateComposite<SequencerNode>(false, Hay_Pistola_, Coger_Pistola);
		Intentar_Pistola.IsRandomized = false;
		
		SuccesFailAction Hay_Cañon__action = new SuccesFailAction();
		LeafNode Hay_Cañon_ = newbehaviourtreegraph.CreateLeafNode(Hay_Cañon__action);
		
		SuccesFailAction Esta_Cargado__action = new SuccesFailAction();
		LeafNode Esta_Cargado_ = newbehaviourtreegraph.CreateLeafNode(Esta_Cargado__action);
		
		SuccesFailAction Montarse_en_Cañon_action = new SuccesFailAction();
		LeafNode Montarse_en_Cañon = newbehaviourtreegraph.CreateLeafNode(Montarse_en_Cañon_action);
		
		SequencerNode Intentar_Cañon = newbehaviourtreegraph.CreateComposite<SequencerNode>(false, Hay_Cañon_, Esta_Cargado_, Montarse_en_Cañon);
		Intentar_Cañon.IsRandomized = false;
		
		SuccesFailAction Hay_Cuchillo__action = new SuccesFailAction();
		LeafNode Hay_Cuchillo_ = newbehaviourtreegraph.CreateLeafNode(Hay_Cuchillo__action);
		
		SuccesFailAction Coger_Cuchillo_action = new SuccesFailAction();
		LeafNode Coger_Cuchillo = newbehaviourtreegraph.CreateLeafNode(Coger_Cuchillo_action);
		
		SequencerNode Intentar_Cuchillo = newbehaviourtreegraph.CreateComposite<SequencerNode>(false, Hay_Cuchillo_, Coger_Cuchillo);
		Intentar_Cuchillo.IsRandomized = false;
		
		SelectorNode Armarse = newbehaviourtreegraph.CreateComposite<SelectorNode>(false, Intentar_Pistola, Intentar_Cañon, Intentar_Cuchillo);
		Armarse.IsRandomized = false;
		
		LoopNode unnamed_4 = newbehaviourtreegraph.CreateDecorator<LoopNode>(Armarse);
		unnamed_4.Iterations = -1;
		
		pushPerceptionDictionary = new Dictionary<String,PushPerception>();
		_12SFSD_gokulegana_ = new PushPerception(Transition2);
		pushPerceptionDictionary.Add(@"_12SFSD@#~@gokulegana~""""",_12SFSD_gokulegana_);
		return newfsmgraph;
	}
}
