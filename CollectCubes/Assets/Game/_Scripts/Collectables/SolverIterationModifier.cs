using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolverIterationModifier : MonoBehaviour
{
	private void Start()
	{
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.solverIterations = 1;
	}
}
