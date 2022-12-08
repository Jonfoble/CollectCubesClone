using UnityEngine;

namespace CC
{
	public class EndNotifier : MonoBehaviour
	{
		private int score;
		private void OnEnable()
		{
			Gatherer.Gathered += Count;

		}
		private void OnDisable()
		{
			Gatherer.Gathered -= Count;
		}

		private void Update()
		{
			if (score > CollectableSpawner.listAmount)
			{
				EndLevel();
				score = 0;
				Debug.Log("Level Ended");
			}
		}

		public void Count()
		{
			score++;
		}


		public void EndLevel()
		{
			GameManager.Instance.LevelEnd();
		}
	}
}