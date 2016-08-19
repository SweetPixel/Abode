using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour {

	public GameObject dialogue;

	void UpdateText(string text)
	{
		dialogue.GetComponent<Text> ().text = text;
	}

}
