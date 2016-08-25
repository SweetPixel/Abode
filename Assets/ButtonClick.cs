using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {

	public void restartLevel()
	{
		SceneManager.LoadSceneAsync ("Gameplay");
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

}
