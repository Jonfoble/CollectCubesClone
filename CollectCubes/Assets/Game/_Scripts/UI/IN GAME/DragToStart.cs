using DG.Tweening;
using TMPro;
using UnityEngine;
namespace CC.UI
{
	public class DragToStart : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI dragToStart;


		private void Start()
		{
			DragToStartEffect();
		}

		public void DragToStartEffect()
		{
			dragToStart.transform.DOScale(new Vector3(.5f, .5f, .5f), 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		}
	}
}