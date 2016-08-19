using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

	public GameObject door;
	public string status = "idle";
	public bool isRight = false;

	public bool isOpen = false;
	private float duration = 2f;

	void Update()
	{

		/*if (status == "open") {
			float yRotation = -90.0f;
			//door.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, yRotation);
			door.transform.eulerAngles = Vector3.Lerp (door.transform.eulerAngles, new Vector3 (door.transform.eulerAngles.x, yRotation, door.transform.eulerAngles.y), 1f * Time.deltaTime);
			if (door.transform.rotation.y == -90f) {
				status = "idle";
			}
		}

		if (status == "close") {
			float yRotation = 0.0f;
			//door.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, yRotation);
			door.transform.eulerAngles = Vector3.Lerp (new Vector3 (door.transform.eulerAngles.x, door.transform.eulerAngles.y, door.transform.eulerAngles.y), new Vector3 (door.transform.eulerAngles.x, yRotation, door.transform.eulerAngles.y), 1f * Time.deltaTime);
			status = "idle";
		}*/

		if (isOpen) {
			duration = duration - Time.deltaTime;
			if (duration < 0) {
				door.GetComponent<Animator> ().SetBool ("isRight", false);
				door.GetComponent<Animator> ().SetBool ("isLeft", false);
				duration = 2f;
				isOpen = false;
			}
		}


	}

	/*void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "Player") {
			if (!isOpen) {
				if (isRight) {
					if (!door.GetComponent<Animator> ().GetBool ("isLeft")) {
						door.GetComponent<Animator> ().SetBool ("isRight", true);
					}
				} else {
					if (!door.GetComponent<Animator> ().GetBool ("isRight")) {
						door.GetComponent<Animator> ().SetBool ("isLeft", true);
					}
				}
				isOpen = true;
			}
		}
	}*/

}
