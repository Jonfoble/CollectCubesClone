using UnityEngine;

public class AISpawner : MonoBehaviour
{
	[SerializeField] private GameObject AIspawnPoint;
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
		transform.SetPositionAndRotation(AIspawnPoint.transform.position, AIspawnPoint.transform.rotation);
	}
}
