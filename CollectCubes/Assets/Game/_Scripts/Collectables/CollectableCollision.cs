using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollision : MonoBehaviour
{
	[SerializeField] private Collider coll;
	public bool isCollected;

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("AI"))
		{
			isCollected = true;
		}
	}
}
