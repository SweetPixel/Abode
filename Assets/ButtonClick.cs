using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {

	public void restartLevel()
	{
		Application.LoadLevelAsync ("Gameplay");
	}
}
