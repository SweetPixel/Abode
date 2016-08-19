using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour {

	public float minTime = 0.05f;
	public float maxTime = 1.3f;

	private float timer;
	public Light l;

	// Use this for initialization
	void Start () {
		timer = Random.Range (minTime, maxTime);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			l.enabled = !l.enabled;
			timer = Random.Range (minTime, maxTime); 
		}
	}
}
