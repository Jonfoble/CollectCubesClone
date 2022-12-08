using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GathererAI : MonoBehaviour
{
	public StateMachine StateMachine => GetComponent<StateMachine>();
	public Transform Target;
	private void Awake()
	{
		InitializeStateMachine();
	}
	private void InitializeStateMachine()
	{
		var states = new Dictionary<Type, BaseState>()
		{
			{typeof(WanderState), new WanderState(this) },
			{typeof(GatherState), new GatherState(this) }
		};
		GetComponent<StateMachine>().SetStates(states);
	}
	public void SetTarget(Transform target)
	{
		Target = target;
	}
}
