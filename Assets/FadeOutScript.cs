using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOutScript : MonoBehaviour {

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
			gameObject.GetComponent<Image> ().CrossFadeAlpha (1f, 1f, false);
		}
	}
}
