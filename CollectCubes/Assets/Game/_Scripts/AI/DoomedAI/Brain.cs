using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private Transform cube;
	[SerializeField] private Transform gatherer;
	[SerializeField] private LayerMask whatIsCube, whatIsGround;
	//States

	[SerializeField] private float sightRange;
	[SerializeField] private bool cubeInSightRange, alreadyCollected;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	private void OnEnable()
	{
		GameManager.Instance.OnGameRunning += StartAI;
		GameManager.Instance.OnCubesAreCreated += FindCube;
	}
	private void OnDisable()
	{
		GameManager.Instance.OnGameRunning -= StartAI;
		GameManager.Instance.OnCubesAreCreated -= FindCube;
	}
	private void Update()
	{
		cubeInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsCube);
	}

	private void CollectCube()
	{
		agent.SetDestination(cube.position);
		Vector3 distanceToWalkPoint = transform.position - cube.position;

		Vector3 lookAtPos = cube.position - transform.position;
		Quaternion newRotation = Quaternion.LookRotation(lookAtPos, transform.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
		Debug.Log(distanceToWalkPoint.magnitude);
		if (distanceToWalkPoint.magnitude < 3f)
		{
			alreadyCollected = true;
		}

	}
	private void GatherCube()
	{
		agent.SetDestination(gatherer.position);
		Vector3 distanceToWalkPoint = transform.position - gatherer.position;

		Vector3 lookAtPos = gatherer.position - transform.position;
		Quaternion newRotation = Quaternion.LookRotation(lookAtPos, transform.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
		if (distanceToWalkPoint.magnitude < 3f)
		{
			FindCube();
			alreadyCollected = false;
		}
	}
	private void FindCube()
	{
		cube = GameObject.Find("CollectableOnTimer(Clone)").transform;
	}
	private void StartAI()
	{
		if (cubeInSightRange && !alreadyCollected) CollectCube();
		if (cubeInSightRange && alreadyCollected) GatherCube();
	}
}
