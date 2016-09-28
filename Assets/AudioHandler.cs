using UnityEngine;
using System.Collections;

public class AudioHandler : MonoBehaviour {

	public AudioClip openAudio;

	public void PlaySound()
	{
		//gameObject.GetComponent<AudioSource> ().clip = openAudio;
		gameObject.GetComponent<AudioSource> ().Play ();
	}

	/*void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player") {
			if (rightCollider.GetComponent<OpenDoorScript> ().isOpen || leftCollider.GetComponent<OpenDoorScript> ().isOpen) {
				if (!isPlayed) {
					
				}
				isPlayed = true;
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.name == "Player") {
			if (!rightCollider.GetComponent<OpenDoorScript> ().isOpen || !leftCollider.GetComponent<OpenDoorScript> ().isOpen) {
				isPlayed = false;
			}
		}
	}*/
}
