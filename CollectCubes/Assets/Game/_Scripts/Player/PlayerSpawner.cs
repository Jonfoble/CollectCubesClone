using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CC
{
	public class PlayerSpawner : MonoBehaviour
	{

		[SerializeField] private GameObject spawnPoint;
		private void OnEnable()
		{
			GameManager.Instance.OnNextLevel += GoToStartPosition;
			GameManager.Instance.OnLevelStart += GoToStartPosition;
			GameManager.Instance.OnGameRestart += GoToStartPosition;
		}
		private void OnDisable()
		{
			GameManager.Instance.OnGameRestart -= GoToStartPosition;
			GameManager.Instance.OnNextLevel -= GoToStartPosition;
			GameManager.Instance.OnLevelStart -= GoToStartPosition;
		}
		public void GoToStartPosition()
		{
			transform.position = spawnPoint.transform.position;
			transform.rotation = spawnPoint.transform.rotation;
		}
	}
}