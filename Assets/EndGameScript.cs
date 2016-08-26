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
//		if (XCI.GetButton(XboxButton.B)) {
//			Debug.Log ("button");
//		}
		if (input > .1f) {
			Debug.Log ("Right");
			selected = "Right";
		} if (input < -.1f) {
			Debug.Log ("Left");
			selected = "Left";
		}
	}

	void Update () {
//		if (XCI.GetButton(XboxButton.B)) {
//			Debug.Log ("button");
//			Debug.Log (check);
//			Debug.Log (selected);
//		}
		if (selected == "Right" && XCI.GetButton(XboxButton.B) && check == false ) {
			check = true;
			ButtonClick button = gameController.GetComponent<ButtonClick> ();
			button.QuitGame ();
		} if (selected == "Left" && XCI.GetButton (XboxButton.B) && check == false) {
			check = true;
			//Debug.Log ("Restarting");
			ButtonClick button = gameController.GetComponent<ButtonClick> ();
			button.restartLevel ();
		}
	}
}
