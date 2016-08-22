using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject helper;

	// Use this for initialization
	void Start () {
		helper = GameObject.Find ("HelpingText");
		helper.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void enableHelper()
	{
		helper.SetActive (true);
	}

	public void disableHelper()
	{
		helper.SetActive (false);
	}
}
