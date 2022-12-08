using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CC.UI
{
	public class DeactivateStartObjects : MonoBehaviour
	{
		private void OnEnable()
		{
			GameManager.Instance.OnGameRestart += Activate;
			GameManager.Instance.OnNextLevel += Activate;
			GameManager.Instance.OnLevelStart += Deactivate;
			GameManager.Instance.OnGameEnd += Deactivate;
		}
		private void OnDisable()
		{
			GameManager.Instance.OnGameRestart -= Activate;
			GameManager.Instance.OnNextLevel -= Activate;
			GameManager.Instance.OnLevelStart -= Deactivate;
			GameManager.Instance.OnGameEnd -= Deactivate;
		}

		public void Activate()
		{
			gameObject.SetActive(true);
		}
		public void Deactivate()
		{
			gameObject.SetActive(false);
		}
	}
}