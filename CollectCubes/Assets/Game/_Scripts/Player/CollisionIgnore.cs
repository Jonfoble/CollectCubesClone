using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
	BoxCollider collider1;
	BoxCollider collider2;
	BoxCollider collider3;

	private void Start()
	{
		collider1 = GetComponents<BoxCollider>()[0];
		collider2 = GetComponents<BoxCollider>()[1];
		collider3 = GetComponents<BoxCollider>()[2];
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("AI"))
		{
			Physics.IgnoreCollision(collider1, other.GetComponents<BoxCollider>()[0], true);
			Physics.IgnoreCollision(collider2, other.GetComponents<BoxCollider>()[1], true);
			Physics.IgnoreCollision(collider3, other.GetComponents<BoxCollider>()[2], true);
		}
	}
}
