using UnityEngine;

namespace CC.UI
{
	public class LevelEndPanelHandler : MonoBehaviour
	{
		[SerializeField] private GameObject endGamePanel;
		private void OnEnable()
		{
			GameManager.Instance.OnLevelEnd += Activate;
			GameManager.Instance.OnNextLevel += Deactivate;
		}
		private void OnDisable()
		{
			GameManager.Instance.OnLevelEnd -= Activate;
			GameManager.Instance.OnNextLevel -= Deactivate;
		}
		public void Activate()
		{
			endGamePanel.gameObject.SetActive(true);
		}
		public void Deactivate()
		{
			endGamePanel.gameObject.SetActive(false);
		}
	}
}