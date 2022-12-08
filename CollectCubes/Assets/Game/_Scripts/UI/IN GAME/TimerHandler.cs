using Jonfoble.ScriptableSystem;
using TMPro;
using UnityEngine;

namespace CC.UI
{
	public class TimerHandler : MonoBehaviour
	{
		[SerializeField] private ScriptableLevelWithTimer level;
		[SerializeField] private TextMeshProUGUI timerText;

		private void OnEnable()
		{
			GameManager.Instance.OnGameRestart += ResetTime;
			GameManager.Instance.OnGameRunning += Count;
		}
		private void OnDisable()
		{
			GameManager.Instance.OnGameRestart -= ResetTime;
			GameManager.Instance.OnGameRunning -= Count;
		}
		public void Count()
		{
			if (level.desiredTime > 0)
			{
				level.desiredTime -= Time.deltaTime;
				timerText.text = "TIME LEFT: " + ((int)level.desiredTime).ToString();

			}
			else
			{
				GameManager.Instance.OnTimesUP?.Invoke();
				GameManager.Instance.isGameRunning = false;
			}
		}
		public void ResetTime()
		{
			level.desiredTime = 60;
			timerText.text = "TIME LEFT: " + ((int)level.desiredTime).ToString();
			GameManager.Instance.isGameRunning = false;
		}
	}
}