using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{

	public void LoadScene(int index)
	{
		SceneManager.LoadScene(index);
	}
	public void QuitGame()
	{
		Application.Quit();
	}


}
