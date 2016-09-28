using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class TimerScript : MonoBehaviour {

	public float duration = 4f;
	public GameObject title;
	public GameObject poem;
	public GameObject hint;
	public GameObject skipButton;
	float audioVolumn = 0.5f;
    AsyncOperation asyncOpration;

	private bool isSkipped = false;

	// Use this for initialization
	void Start () {
		skipButton.SetActive (false);
        asyncOpration = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Gameplay");
        asyncOpration.allowSceneActivation = false;
	}
	
	// Update is called once per frame
	void Update () {
		duration = duration - Time.deltaTime;

		int count = PlayerPrefs.GetInt ("playCount");

		if (duration < 21) {
			if (!GameObject.Find ("GameController").GetComponent<AudioSource> ().isPlaying) {
				GameObject.Find("GameController").GetComponent<AudioSource> ().Play ();
                Debug.Log("audio");
			}

			hint.SetActive (false);
			poem.SetActive (true);

			if (count > 0) {
				isSkipped = true;
				skipButton.SetActive (true);
			}
		}
		if (duration < 0) {
			//Application.LoadLevelAsync ("Gameplay");
            asyncOpration.allowSceneActivation = true;
			
		}



		if (isSkipped) {
			if (Input.GetKey (KeyCode.JoystickButton1) || Input.GetKey (KeyCode.E) || XCI.GetButton(XboxButton.B)) {
				duration = 3;
				poem.SetActive (false);
				isSkipped = false;
			}
		}

		if (duration < 3) {
			audioVolumn -= 0.1f * Time.deltaTime;
			GameObject.Find ("GameController").GetComponent<AudioSource> ().volume = audioVolumn;
			poem.SetActive (false);
			title.SetActive (true);
		}
		if (duration < 0) {
			PlayerPrefs.SetInt ("playCount", 1);
			//Application.LoadLevelAsync ("Gameplay");
            asyncOpration.allowSceneActivation = true;
		}
	}
}
