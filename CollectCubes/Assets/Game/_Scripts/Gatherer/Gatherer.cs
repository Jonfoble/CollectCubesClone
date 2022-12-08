using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace CC
{
	public class Gatherer : MonoBehaviour
	{
		public static UnityAction Gathered;
		[SerializeField] Color targetColor;
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Collectable"))
			{
				other.GetComponent<MeshRenderer>().material.color = targetColor;
				other.transform.DOMove(transform.position, .3f).OnComplete(() =>
				{
					Gathered?.Invoke();
				    ObjectPoolManager.Instance.AddObject("Cube", other.gameObject);
				});
			}
		}
	}
}