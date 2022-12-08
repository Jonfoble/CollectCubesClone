using Jonfoble.ScriptableSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	#region GAME STATE EVENTS
	public UnityAction OnLevelStart;//Action on Level Start

	public UnityAction OnGameRunning;//Action when game running

	public UnityAction OnGameEnd;//Action when game ends

	public UnityAction OnNextLevel;//Action on next level

	public UnityAction OnLevelEnd;//Action on level end

	public UnityAction OnGameRestart;//Action on restart

	public UnityAction OnTimesUP;//Action on TimesUP

	public UnityAction OnCubesAreCreated;//Action on Cubes are created

	public bool isGameRunning;
	#endregion
	#region Scriptable Actions
	[SerializeField] ScriptableAction OnGameStartAction;//Scriptable action on Game Start
	#endregion
	public int currentLevel = 1; //Levels
	private void Update()
	{
		if (isGameRunning)
		{
			OnGameRunning?.Invoke();
		}
	}
	public void LoadNextLevel()
	{
		currentLevel++;
		isGameRunning = true;
		OnNextLevel?.Invoke();
		
	}
	public void RestartLevel()
	{
		OnGameRestart?.Invoke();
	}
	public void StartLevel()
	{
		isGameRunning = true;
		OnLevelStart?.Invoke();
	}
	public void LevelEnd()
	{
		isGameRunning = false;
		OnLevelEnd?.Invoke();
	}
	public void StartGame() 
	{
		OnGameStartAction.CallAction();
	}
	public void GoToMenu(int index)
	{
		SceneManager.LoadScene(index);
	}
}