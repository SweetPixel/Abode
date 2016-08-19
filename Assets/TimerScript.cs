using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

	public float duration = 4f;
	public GameObject title;
	public GameObject poem;
	public GameObject hint;
	float audioVolumn = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		duration = duration - Time.deltaTime;

		if (duration < 21) {
			if (!GameObject.Find ("GameController").GetComponent<AudioSource> ().isPlaying) {
				GameObject.Find("GameController").GetComponent<AudioSource> ().Play ();
			}

			hint.SetActive (false);
			poem.SetActive (true);
		}
		if (duration < 0) {
			Application.LoadLevelAsync ("Gameplay");
		}

		if (duration < 3) {
			audioVolumn -= 0.1f * Time.deltaTime;
			GameObject.Find ("GameController").GetComponent<AudioSource> ().volume = audioVolumn;
			poem.SetActive (false);
			title.SetActive (true);
		}
		if (duration < 0) {
			Application.LoadLevelAsync ("Gameplay");
		}
	}
}
