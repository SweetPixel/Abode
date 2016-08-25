using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class EndGameScript : MonoBehaviour {

	public float duration = 2f;
	public GameObject canvas;
	private string selected = "Left";
	private bool check = false;

	private GameObject gameController;

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		gameController = GameObject.Find ("GameController");
	}

	public void ShowCanvas()
	{
		canvas.SetActive (true);
	}

	// Update is called once per frame
	void FixedUpdate () {
		float input = Input.GetAxis ("Horizontal");
//		if (input == 0) {
//			selected = null;
//		}
		if (input > .1f) {
			
			selected = "Right";
		} if (input < -.1f) {
			
			selected = "Left";
		}
	}

	void Update () {
		if (selected == "Right" && XCI.GetButton(XboxButton.B) && check == false ) {
			check = true;
			ButtonClick button = gameController.GetComponent<ButtonClick> ();
			button.QuitGame ();
		} if (selected == "Left" && XCI.GetButton (XboxButton.B) && check == false) {
			check = true;
			ButtonClick button = gameController.GetComponent<ButtonClick> ();
			button.restartLevel ();
		}
	}
}
