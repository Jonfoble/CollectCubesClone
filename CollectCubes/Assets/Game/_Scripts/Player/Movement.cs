using UnityEngine.EventSystems;
using UnityEngine;
using Jonfoble.ScriptableSystem;

namespace CC.Movement
{
	public class Movement : MonoBehaviour
	{
		[SerializeField] private ScriptableInt playerSpeed;
		[SerializeField] private ScriptableFloat rotationSpeed;

		private Rigidbody body;
		private void Awake()
		{
			body = gameObject.GetComponent<Rigidbody>();
		}
		private void FixedUpdate()
		{
			if (InputHandler.isInputTaken && InputHandler.Instance.DragDetector())
			{
				PlayerMovement();
			}
		}
		public void PlayerMovement()
		{
			PlayerRotation(transform.position + InputHandler.MovementInput);//Rotation
			body.AddForce(InputHandler.MovementInput.normalized * playerSpeed.GetValue(), ForceMode.Impulse);//Movement
		}
		public void PlayerRotation(Vector3 target)
		{
			//Rotation
			float playerDistanceToFloor = gameObject.transform.position.y - target.y;
			target.y += playerDistanceToFloor;
			Vector3 direction = target - gameObject.transform.position;
			gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(direction.normalized), rotationSpeed.GetValue() * Time.fixedDeltaTime);
		}
	}
}