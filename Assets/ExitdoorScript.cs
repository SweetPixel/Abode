using UnityEngine;
using System.Collections;

public class ExitdoorScript : MonoBehaviour {

	public AudioClip openAudio;
	public AudioClip closeAudio;
	public GameObject door;
	public bool isRight = false;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player") {
			if (col.gameObject.GetComponent<PlayerMovement> ().hasKey && gameObject.name == "leftCollider (16)") {
				/*gameObject.GetComponent<AudioSource> ().clip = openAudio;
				gameObject.GetComponent<AudioSource> ().Play ();*/
				if (isRight) {
					door.GetComponent<Animator> ().SetBool ("isRight", true);
				} else {
					door.GetComponent<Animator> ().SetBool ("isLeft", true);
				}
				StartCoroutine (endLevel());
			}

		}
	}

	IEnumerator endLevel()
	{
		yield return new WaitForSeconds (2f);
		Application.LoadLevelAsync ("EndScene");
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.name == "Player") {
			if (isRight) {
				door.GetComponent<Animator> ().SetBool ("isRight", false);
			} else {
				door.GetComponent<Animator> ().SetBool ("isLeft", false);
			}
			/*gameObject.GetComponent<AudioSource> ().clip = openAudio;
			gameObject.GetComponent<AudioSource> ().Play ();*/
		}
	}
}
