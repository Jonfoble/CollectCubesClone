using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
namespace CC.UI
{
	public class HandHandler : MonoBehaviour
	{

		private void Start()
		{
			Slide();
		}

		public void Slide()
		{
			gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(137f, -156f), 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		}

	}
}