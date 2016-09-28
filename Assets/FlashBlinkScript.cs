using UnityEngine;
using System.Collections;

public class FlashBlinkScript : MonoBehaviour {

	public int intensity = 5;
	public GameObject light;
	public float blinkDelay = 0.25f;
	private bool initial = true;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player" && initial) {
			StartCoroutine (FlashBlink ());
			initial = false;
		}
	}

	IEnumerator FlashBlink()
	{
		yield return new WaitForSeconds (1f);
		for (int i = 0; i < intensity; i++) {
			if (light != null) {
				light.SetActive (false);
				yield return new WaitForSeconds (blinkDelay);
				light.SetActive (true);
				yield return new WaitForSeconds (blinkDelay);
			}
		}
	}


}
