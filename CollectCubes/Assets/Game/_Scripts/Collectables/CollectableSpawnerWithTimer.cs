using Jonfoble.ScriptableSystem;
using UnityEngine;

namespace CC
{
	public class CollectableSpawnerWithTimer : MonoBehaviour
	{
		[SerializeField] private ScriptableLevelWithTimer level;

		float x = 0f, z = 0f;

		private void Start()
		{
			CreateCubes();
		}

		public void CreateCubes()
		{
			//SPAWNING CUBES OVER TIME
			GameObject newObject = ObjectPoolManager.Instance.GetObject("Cube");
			if (newObject == null)
			{
				for (int i = 0; i < level.desiredPrefabAmount; i++)
				{
					newObject = Instantiate(level.cube, transform.position, Quaternion.identity, this.transform);
				}
				GameManager.Instance.OnCubesAreCreated?.Invoke();
			}
			newObject.transform.localPosition = new Vector3(x, newObject.transform.localPosition.y, z);
		}
	}
}
