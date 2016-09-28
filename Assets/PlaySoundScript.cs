using UnityEngine;
using System.Collections;

public class PlaySoundScript : MonoBehaviour {

	public AudioClip audio;
	public GameObject key;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "lightRange") {
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			gameObject.GetComponent<AudioSource> ().clip = audio;
			gameObject.GetComponent<AudioSource> ().Play ();
			key.SetActive (true);
		}
	}

}
