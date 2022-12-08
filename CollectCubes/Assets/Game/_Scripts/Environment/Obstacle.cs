using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
	public static UnityAction OnPlayerExplosion;
	public static UnityAction OnAIExplosion;
	private void Update()
	{
		Rotate();
	}
	public void Rotate()
	{
		transform.Rotate(0, 50 * Time.deltaTime, 0); ;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			ObjectPoolManager.Instance.AddObject("DestroyedPlayer", other.gameObject);
			OnPlayerExplosion?.Invoke();
		}
		else if (other.CompareTag("AI"))
		{
			ObjectPoolManager.Instance.AddObject("DestroyedAI", other.gameObject);
			OnAIExplosion?.Invoke();
		}
	}
}
