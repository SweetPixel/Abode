using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public GameObject go;
	public GameObject title;
	public float duration = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		duration = duration - Time.deltaTime;

		if (duration < 5f) {
			go.SetActive (true);
			title.SetActive (false);
		}

	}
}
