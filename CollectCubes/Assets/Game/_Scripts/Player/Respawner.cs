using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{

	[SerializeField] private GameObject spawnPoint;
	private void OnEnable()
	{
		Obstacle.OnPlayerExplosion += Respawn;
	}
	private void OnDisable()
	{
		Obstacle.OnPlayerExplosion -= Respawn;
	}
	public void Respawn()
	{
		GameObject player = ObjectPoolManager.Instance.GetObject("DestroyedPlayer");
		player.transform.position = spawnPoint.transform.position;
		player.transform.rotation = spawnPoint.transform.rotation;
	}
}
