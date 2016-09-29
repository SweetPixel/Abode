using UnityEngine;
using System.Collections;

public class FlashLightScript : MonoBehaviour {

	public bool isAvailable =false;
	private GameObject gameController;
    [SerializeField]
    private GameObject helperCanvas;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController");
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			isAvailable = true;
		}

	}

	void OnTriggerExit(Collider col)
	{
		isAvailable = false;
	}


}
