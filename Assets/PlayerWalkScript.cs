using UnityEngine;
using System.Collections;

public class PlayerWalkScript : MonoBehaviour {

	public void Walk()
	{
		gameObject.GetComponent<AudioSource> ().Play ();
	}
}
