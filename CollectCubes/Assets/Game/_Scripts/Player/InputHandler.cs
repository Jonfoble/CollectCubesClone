using UnityEngine;
using UnityEngine.EventSystems;

namespace CC.Movement
{
	public class InputHandler : Singleton<InputHandler>, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		public static Vector3 MovementInput;
		public static bool isInputTaken;

		#region PrivateVariables
		private Vector3 priorPos;
		private Vector3 currentPos;
		private bool firstClick = true;
		private int followedPointerID;
		#endregion
		private void OnEnable()
		{
			GameManager.Instance.OnGameRestart += FirstClickReset;
			GameManager.Instance.OnNextLevel += FirstClickReset;
			GameManager.Instance.OnLevelStart += FirstClickReset;
		}
		private void OnDisable()
		{
			GameManager.Instance.OnGameRestart -= FirstClickReset;
			GameManager.Instance.OnNextLevel -= FirstClickReset;
			GameManager.Instance.OnLevelStart -= FirstClickReset;
		}
		public void OnBeginDrag(PointerEventData eventData)//Check if using the same finger OnDragBegin
		{
			followedPointerID = eventData.pointerId;
			if (firstClick)
			{
				GameManager.Instance.StartGame();
				firstClick = false;
			}

		}
		public void OnDrag(PointerEventData eventData)
		{
			if (eventData.pointerId != followedPointerID || !eventData.IsPointerMoving())//Check if	using the same finger when dragging
			{
				isInputTaken = false;
			}
			else
			{
				isInputTaken = true;
				InputPosition(eventData);
			}
			
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.pointerId != followedPointerID)//Check if	using the same finger OnDragEnd
			{
				return;
			}
			MovementInput = Vector3.zero;
			isInputTaken = false;
		}
		public void InputPosition(PointerEventData eventData)
		{
			priorPos = currentPos;
			currentPos = new Vector3(eventData.position.x, 0f, eventData.position.y);
			Vector3 inputData = currentPos - priorPos;
			MovementInput = new Vector3(inputData.x, 0f, inputData.z);
		}
		public void FirstClickReset()
		{
			firstClick = true;
		}
		public bool DragDetector()
		{
			if (Mathf.Abs((priorPos - currentPos).magnitude) < .1f)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

	}
}