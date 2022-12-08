using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherState : BaseState
{
	private GathererAI _gathererAI;
   public GatherState(GathererAI gathererAI) : base(gathererAI.gameObject)
	{
		_gathererAI = gathererAI;
	}
	public override Type Tick()
	{
		if (_gathererAI.Target == null)
		{
			return typeof(WanderState);
		}
			transform.LookAt(_gathererAI.Target);
			transform.Translate(Vector3.forward * Time.deltaTime * AIManager.speedAI);
		return typeof(WanderState);
	}
}
