using CC;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class AIGatherer : MonoBehaviour
{
	public static UnityAction AIGathered;
	[SerializeField] CollectableSpawnerWithTimer spawner;
	[SerializeField] Color targetColor;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Collectable"))
		{
			other.GetComponent<MeshRenderer>().material.color = targetColor;
			other.transform.DOMove(transform.position, .3f).OnComplete(() =>
			{
				AIGathered?.Invoke();
				ObjectPoolManager.Instance.AddObject("Cube", other.gameObject);
				spawner.CreateCubes();
			});
		}
	}
}
