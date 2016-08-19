using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float walkSpeed = 5f;
	public float rotationSpeed = 2f;

	//Lights
	public GameObject flashLight;
	public GameObject flashLight_light;
	public GameObject spotLight;
	public GameObject key;

	private bool isMobile = false;
	private bool movementAllowed = false;

	private AudioSource audio;
	public AudioClip Voice2;
	public AudioClip girlSound;
	public AudioClip maleVoice;
	public GameObject blinkingMobile;
	public AudioClip keySound;

	public AudioClip[] dialogues;
	private int totalLength;
	public bool isOpen = false;
	private bool isKey = false;
	public bool hasKey = false;

	public AudioClip clockRoomDialogue;

	Vector3 forward;
	Vector3 right;
	float currentLerpTime;

	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		GameObject.Find ("GameController").GetComponent<HelperScript> ().SendMessage ("UpdateText", "Press 'A' to move.");
		audio = GameObject.Find ("GameController").GetComponent<AudioSource> ();

		totalLength = dialogues.Length;
		flashLight.SetActive (false);

		forward = Camera.main.transform.forward;
		forward. y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0,90,0)) * forward;

	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W)) {
			transform.position += transform.forward * Time.deltaTime * walkSpeed;
		}

		if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.W)) {
			GameObject.Find ("GameController").GetComponent<HelperScript> ().SendMessage ("UpdateText", "");
			gameObject.GetComponent<Animator> ().SetBool ("isMoving", true);
		}

		if (Input.GetKeyUp(KeyCode.JoystickButton0) || Input.GetKeyUp(KeyCode.W)) {
			gameObject.GetComponent<Animator> ().SetBool ("isMoving", false);
		}

		currentLerpTime += Time.deltaTime;

		if (movementAllowed) {
			float rotatePosX = Input.GetAxis ("Horizontal");

			float rotatePostY = Input.GetAxis ("Vertical");

			Vector3 direction = new Vector3(rotatePosX, 0f, rotatePostY);

			if (rotatePosX > 0) {
				GameObject.Find ("GameController").GetComponent<HelperScript> ().SendMessage ("UpdateText", "");
			}
			this.transform.Rotate(0, rotatePosX* rotationSpeed, 0);

			/*float heading = Mathf.Atan2(rotatePosX,rotatePostY);

			transform.rotation= Quaternion.LookRotation(direction);*/


			/*if (direction.magnitude > 0.5f)
			{
				Vector3 rightMovement = right * 10f * Time.deltaTime * rotatePosX;
				Vector3 upMovement = forward * 10f * Time.deltaTime * rotatePostY;

				Vector3 heading = Vector3.Normalize(rightMovement+upMovement);
				transform.forward = heading;

				//transform.position += rightMovement;
				//transform.position += upMovement;
			}*/

		}



		if (Input.GetKey(KeyCode.JoystickButton1) || Input.GetKey(KeyCode.E)) {

			if (spotLight.GetComponent<FlashLightScript> ().isAvailable && !movementAllowed) {
				audio.clip = Voice2;
				audio.Play ();
				movementAllowed = true;
				spotLight.SetActive (false);

				gameObject.GetComponent<CapsuleCollider> ().enabled = true;
				if (!flashLight.activeInHierarchy) {
					flashLight.SetActive (true);
					StartCoroutine (PlaySounds ());
				}
				GameObject.Find ("GameController").GetComponent<HelperScript> ().SendMessage ("UpdateText", "Use arrows to Left/Right!");
			}

			if (isMobile) {
				GameObject.FindGameObjectWithTag ("Mobile").SetActive (false);
				isMobile = false;
				StartCoroutine (PlayAllDialogues ());
			}

			if (isKey) {
				GetComponent<AudioSource>().clip = keySound;
				GetComponent<AudioSource>().Play ();
				hasKey = true;
				key.SetActive (false);
			}

		}

	}

	IEnumerator PlaySounds()
	{
		yield return new WaitForSeconds (4f);
		audio.clip = girlSound;
		audio.Play ();
		yield return new WaitForSeconds (3f);
		audio.clip = maleVoice;
		audio.Play ();
		yield return new WaitForSeconds (5f);
		blinkingMobile.GetComponent<AudioSource> ().enabled = true;
	}

	IEnumerator PlayAllDialogues()
	{
		GetComponent<AudioSource>().clip = dialogues[0];
		GetComponent<AudioSource>().Play ();
		Debug.Log (GetComponent<AudioSource>().clip);
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[1];
		GetComponent<AudioSource>().Play ();
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[2];
		GetComponent<AudioSource>().Play ();
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[3];
		GetComponent<AudioSource>().Play ();
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[4];
		GetComponent<AudioSource>().Play ();
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[5];
		GetComponent<AudioSource>().Play ();
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[6];
		GetComponent<AudioSource>().Play ();
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
	}

	void OnTriggerStay(Collider col)
	{
		Debug.Log (col.gameObject.tag);

		if (col.gameObject.tag == "Mobile") {
			isMobile = true;
		}

		if (col.gameObject.tag == "Key") {
			isKey = true;
		}

		if (col.gameObject.tag == "rightDoorCollider") {
			if (Input.GetKey (KeyCode.JoystickButton1) || Input.GetKey (KeyCode.E)) {
				col.gameObject.GetComponent<OpenDoorScript> ().door.GetComponent<Animator> ().SetBool ("isRight", true);
				col.gameObject.GetComponent<OpenDoorScript> ().isOpen = true;
			}
		}

		if (col.gameObject.tag == "leftDoorCollider") {
			if (Input.GetKey (KeyCode.JoystickButton1) || Input.GetKey (KeyCode.E)) {
				col.gameObject.GetComponent<OpenDoorScript> ().door.GetComponent<Animator> ().SetBool ("isLeft", true);
				col.gameObject.GetComponent<OpenDoorScript> ().isOpen = true;
			}
		}

	}

	void OnTriggerLeave(Collider col)
	{
		if (col.gameObject.tag == "Mobile") {
			isMobile = false;
		}

		if (col.gameObject.tag == "Key") {
			isKey = false;
		}

	}

	void OnCollisionEnter(Collision col)
	{
		gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}

}
