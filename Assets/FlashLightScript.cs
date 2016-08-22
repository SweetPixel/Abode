using UnityEngine;
using System.Collections;

public class FlashLightScript : MonoBehaviour {

	public bool isAvailable =false;
	private GameObject gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController");
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			isAvailable = true;
			gameController.GetComponent<GameController> ().enableHelper ();
		}

	}

	void OnTriggerExit(Collider col)
	{
		gameController.GetComponent<GameController> ().disableHelper ();
		isAvailable = false;
	}


}
