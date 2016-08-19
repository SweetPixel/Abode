using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {

	public float duration = 2f;
	public GameObject canvas;

	// Use this for initialization
	void Start () {
	
	}

	public void ShowCanvas()
	{
		canvas.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
	}
}
