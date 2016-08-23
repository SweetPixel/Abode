using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	private bool isClosing = false;
	private bool isOpening = false;

	public GameObject door;

	public Animation openDoor;

	// Use this for initialization
	void Start () {
	
	}

	void Update()
	{
		if (isOpening && !isClosing) {

			Debug.Log ("IsOpening");


			isOpening = false;
			/*var target = Quaternion.Euler (0f, -85f, 0f);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, target, Time.deltaTime * 2f);

			if (transform.rotation.y > 86) {
				isOpening = false;
			}*/
		}

		if (!isOpening && isClosing) {

			/*Debug.Log ("IsClosing");

			var target = Quaternion.Euler (0f, 0f, 0f);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, target, Time.deltaTime * 2f);

			if (transform.rotation.y < 1) {
				isClosing = false;
			}*/


			isClosing = false;
		}

	}

	void OnTriggerEnter(Collider col)
	{

		//Debug.Log (col.gameObject.name);

		if (col.gameObject.name == "lightRange") {
			return;
		}

		if (col.gameObject.name == "character") {
			isOpening = true;
			isClosing = false;
			door.GetComponent<Animator> ().SetBool ("isOpen", true);
		}

	}

	void OnTriggerExit(Collider col)
	{
		//Debug.Log (col.gameObject.name);

		if (col.gameObject.name == "lightRange") {
			return;
		}

		if (col.gameObject.name == "character") {
			isClosing = true;
			isOpening = false;
			door.GetComponent<Animator> ().SetBool ("isOpen", false);
		}

	}

}
