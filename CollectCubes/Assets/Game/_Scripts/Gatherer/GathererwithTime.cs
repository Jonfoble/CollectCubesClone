using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CC.UI
{
    public class GathererwithTime : MonoBehaviour
    {
        public static UnityAction Gathered;
		[SerializeField] CollectableSpawnerWithTimer spawner;
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
					spawner.CreateCubes();
				});
			}
		}
    }
}