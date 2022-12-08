using TMPro;
using UnityEngine;

namespace CC.UI
{
	public class EndPanelScoreHandler : MonoBehaviour
	{
		[SerializeField] TextMeshProUGUI endScoreText;
		[SerializeField] TextMeshProUGUI endScorePanelText;

		private void OnEnable()
		{
			GameManager.Instance.OnTimesUP += SetEndScore;
		}
		private void OnDisable()
		{
			GameManager.Instance.OnTimesUP -= SetEndScore;
		}


		public void SetEndScore()
		{
		    endScorePanelText.text = endScoreText.text;
		}
	}
}