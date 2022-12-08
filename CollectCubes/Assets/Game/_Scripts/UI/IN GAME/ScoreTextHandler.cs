using TMPro;
using UnityEngine.UI;
using UnityEngine;
using CC.UI;

namespace CC
{
	public class ScoreTextHandler : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI scoreText;
		private int score = 0;

		private void OnEnable()
		{
			GameManager.Instance.OnGameRestart += CountReset;
			GathererwithTime.Gathered += Count;
			
		}
		private void OnDisable()
		{
			GameManager.Instance.OnGameRestart -= CountReset;
			GathererwithTime.Gathered -= Count;
		}

		public void Count()
		{
			score++;
			scoreText.text = "Score: " + score;
		}
		public void CountReset()
		{
			score = 0;
			scoreText.text = "Score: " + score;
		}


	}
}