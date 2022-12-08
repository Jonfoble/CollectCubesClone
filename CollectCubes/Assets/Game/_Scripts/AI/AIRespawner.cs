using UnityEngine;

public class AIRespawner : MonoBehaviour
{
	[SerializeField] private GameObject AIspawnPoint;
	private void OnEnable()
	{
		Obstacle.OnAIExplosion += Respawn;
	}
	private void OnDisable()
	{
		Obstacle.OnAIExplosion -= Respawn;
	}
	public void Respawn()
	{
		GameObject AI = ObjectPoolManager.Instance.GetObject("DestroyedAI");
		AI.transform.position = AIspawnPoint.transform.position;
		AI.transform.rotation = AIspawnPoint.transform.rotation;
	}
}
