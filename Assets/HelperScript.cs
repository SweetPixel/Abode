using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelperScript : MonoBehaviour {

	public GameObject helperText;

	void UpdateText(string text)
	{
		helperText.GetComponent<Text> ().text = text;
	}


}
