using UnityEngine;
using System.Collections;

public class BlinkingScript : MonoBehaviour {

	public int intensity = 10;
	public GameObject gameobject;
	public float blinkDelay = 0.05f;
	public float delayBetweenRing = 0.1f;
	private bool initial = true;
	private int flickerRate = 0;
	private float blinkRate = 0;
	private float delayRate = 0;

	void Start()
	{
		flickerRate = Random.Range (10, intensity);
		blinkRate = Random.Range (0.005f, blinkDelay);
		delayRate = Random.Range (0f, delayBetweenRing);
		StartCoroutine (FlashBlink ());
	}

	/*void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player" && initial) {
			StartCoroutine (FlashBlink ());
			initial = false;
		}
	}*/

	IEnumerator FlashBlink()
	{
		while (true) {
			for (int i = 0; i < flickerRate; i++) {
				gameobject.SetActive (false);
				yield return new WaitForSeconds (blinkRate);
				gameobject.SetActive (true);
				yield return new WaitForSeconds (blinkRate);
			}
			gameobject.SetActive (false);
			yield return new WaitForSeconds (delayBetweenRing);
			flickerRate = Random.Range (10, intensity);
			blinkRate = Random.Range (0.005f, blinkDelay);
			delayRate = Random.Range (0f, delayBetweenRing);
		}
	}
}
