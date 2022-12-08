using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CC.UI
{
	public class TimesUpPanelHandler : MonoBehaviour
	{
		[SerializeField] private GameObject timesUpPanel;
		private void OnEnable()
		{
			GameManager.Instance.OnTimesUP += Activate;
			GameManager.Instance.OnGameRestart += Deactivate;
		}
		private void OnDisable()
		{
			GameManager.Instance.OnTimesUP -= Activate;
			GameManager.Instance.OnGameRestart -= Deactivate;
		}
		public void Activate()
		{
			timesUpPanel.SetActive(true);
		}
		public void Deactivate()
		{
			timesUpPanel.SetActive(false);
		}
	}
}