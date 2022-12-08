using CC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : BaseState
{
	#region Private Variables
	private Vector3? _destination;
	private float stopDistance = 1f;
	private float turnSpeed = 1f;
	private readonly LayerMask _layerMask = LayerMask.NameToLayer("Walls");
	private float _rayDistance = 3.5f;
	private Quaternion _desiredRotation;
	private Vector3 _direction;
	private GathererAI _gathererAI;
	#endregion

	public WanderState(GathererAI gathererAI) : base(gathererAI.gameObject)
	{
		_gathererAI = gathererAI;
	}
	public override Type Tick()
	{
		var chaseTarget = CheckForAggro();
		if (chaseTarget != null)
		{
			_gathererAI.SetTarget(chaseTarget);
			return typeof(WanderState);

		}
		if (_destination.HasValue == false || Vector3.Distance(transform.position, _destination.Value) <= stopDistance)
		{
			FindRandomDestination();
		}

		transform.rotation = Quaternion.Slerp(transform.rotation, _desiredRotation, turnSpeed * Time.deltaTime);

		if (IsForwardBlocked())
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, _desiredRotation, .2f);
		}
		else
		{
			transform.Translate(Vector3.forward * Time.deltaTime * AIManager.speedAI);
		}
		Debug.DrawRay(transform.position, _direction * _rayDistance, Color.red);
		while (IsPathBlocked())
		{
			FindRandomDestination();
			Debug.Log("Wall");
		}
		return null;

	}

	private bool IsForwardBlocked()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		return Physics.SphereCast(ray, .5f, _rayDistance, _layerMask);
	}
	private bool IsPathBlocked()
	{
		Ray ray = new Ray(transform.position, _direction);
		return Physics.SphereCast(ray, .5f, _rayDistance, _layerMask);
	}
	private void FindRandomDestination()
	{
		Vector3 testPosition = transform.position + (transform.forward * 4f) +
			new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), 0f, UnityEngine.Random.Range(-4.5f, 4.5f));
		_destination = new Vector3(testPosition.x, 1f, testPosition.z);
		_direction = Vector3.Normalize(_destination.Value - transform.position);
		_direction = new Vector3(_direction.x, 0f, _direction.z);
		_desiredRotation = Quaternion.LookRotation(_direction);
		Debug.Log("Got Direction");
	}
	Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
	Quaternion setpAngle = Quaternion.AngleAxis(5, Vector3.up);
	private Transform CheckForAggro()
	{
		RaycastHit hit;
		var angle = transform.rotation * startingAngle;
		var direction = angle * Vector3.forward;
		var pos = transform.position;
		for (int i = 0; i < 24; i++)
		{
			if (Physics.Raycast(pos,direction,out hit, AIManager.AggroRadius))
			{
				var gathererAI = hit.collider.GetComponent<CollectableSpawner>();
				if (gathererAI != null)
				{
					Debug.DrawRay(pos, direction * hit.distance, Color.red);
					return gathererAI.transform;
				}
				else
				{
					Debug.DrawRay(pos, direction * hit.distance, Color.yellow);
				}
			}
			
		}
		return null;
	}
}
