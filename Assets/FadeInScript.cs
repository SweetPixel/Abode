using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour {

	public float timer = 0;
	private bool isInit = true;
	public GameObject light;
	private GameObject controls;

	// Use this for initialization
	void Start () {
		light.SetActive (false);
		controls = GameObject.Find ("Controls");
		controls.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer < 0 && isInit) {
			isInit = false;
			gameObject.GetComponent<Image> ().CrossFadeAlpha (0, 1f, false);
			if (gameObject.name == "Panel") {
				GameObject.Find ("Player").GetComponent<PlayerMovement> ().supriseSound ();
				GameObject.Find ("Player").GetComponent<PlayerMovement> ().movementAllowed = true;
				light.SetActive (true);
				light.GetComponent<BlinkingScript> ().enabled = true;
				controls.SetActive (true);

			}
		}
	}
}
