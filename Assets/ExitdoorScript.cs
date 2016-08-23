﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitdoorScript : MonoBehaviour {

	public AudioClip withOutKeySound, withOutKeyExit;
	public GameObject door;
	public GameObject key;
	public bool isRight = false;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player") {
			if (col.gameObject.GetComponent<PlayerMovement> ().hasKey && gameObject.name == "leftCollider (16)") {
				door.GetComponent<Animator> ().SetBool ("isRight", true);
				StartCoroutine (endLevel ());
				GameObject.Find ("Player").GetComponent<PlayerMovement> ().objectives [2].GetComponent<Image> ().sprite = GameObject.Find ("Player").GetComponent<PlayerMovement> ().objectivesComplete [2];
			} else if (!col.gameObject.GetComponent<PlayerMovement> ().hasKey && gameObject.name == "leftCollider (16)") {
				gameObject.GetComponent<AudioSource> ().clip = withOutKeyExit;
				gameObject.GetComponent<AudioSource> ().Play ();
				key.SetActive (true);
				GameObject.Find ("Player").GetComponent<PlayerMovement> ().objectives [2].SetActive (true);
			} else {
				gameObject.GetComponent<AudioSource> ().clip = withOutKeySound;
				gameObject.GetComponent<AudioSource> ().Play ();
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
			/*if (isRight) {
				door.GetComponent<Animator> ().SetBool ("isRight", false);
			} else {
				door.GetComponent<Animator> ().SetBool ("isLeft", false);
			}*/
			/*gameObject.GetComponent<AudioSource> ().clip = openAudio;
			gameObject.GetComponent<AudioSource> ().Play ();*/
		}
	}
}