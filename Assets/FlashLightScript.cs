using UnityEngine;
using System.Collections;

public class FlashLightScript : MonoBehaviour {

	public bool isAvailable =false;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			isAvailable = true;
			GameObject.Find ("GameController").GetComponent<HelperScript> ().SendMessage ("UpdateText", "Press 'B' to pick up");
		}

	}

	void OnTriggerExit(Collider col)
	{
		isAvailable = false;
	}


}
