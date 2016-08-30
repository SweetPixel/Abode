using UnityEngine;
﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using XboxCtrlrInput;

public class PlayerMovement : MonoBehaviour {

	public float walkSpeed = 5f;
	public float rotationSpeed = 5f;

	//Lights
	public GameObject flashLight;
	public GameObject flashLight_light;
	public GameObject spotLight;
	public GameObject key;

	public bool isMobile = false;
	public bool movementAllowed = false;

	private AudioSource audio;
	public AudioClip Voice2;
	public AudioClip girlSound;
	public AudioClip maleVoice;
	public GameObject blinkingMobile;
	public AudioClip keySound, GhostWoman;
    public bool hasMobileAttende=false;

	public AudioClip[] dialogues;
	private int totalLength;
	public bool isOpen = false;
	private bool isKey = false;
	public bool hasKey = false;
    private bool isPoemPlayed = false;
	public AudioClip clockRoomDialogue;

	Vector3 forward;
	Vector3 right;
	float currentLerpTime;

	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	private bool isStart = true;
	public GameObject controls;
	private float controlTimer = 2f;
	private GameObject gameController;

	private bool isInitial = true;

	public GameObject[] objectives;
	public Sprite[] objectivesComplete;

	public XboxController playerNumber = XboxController.First;

	// Use this for initialization
	void Start () {
		GameObject.Find ("GameController").GetComponent<HelperScript> ().SendMessage ("UpdateText", "");
		audio = GameObject.Find ("GameController").GetComponent<AudioSource> ();

		totalLength = dialogues.Length;
		//flashLight.SetActive (false);

		forward = Camera.main.transform.forward;
		forward. y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0,90,0)) * forward;

		gameController = GameObject.Find ("GameController");

	}
	
	// Update is called once per frame
	void Update () 
    {
		float rotatePosX = Input.GetAxis ("Horizontal");

		float rotatePostY = Input.GetAxis ("Vertical");

		Vector3 direction = new Vector3(rotatePosX, rotatePostY, 0f);
		/*if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W)) {
			transform.position += transform.forward * Time.deltaTime * walkSpeed;
		}

		if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.W)) {
			GameObject.Find ("GameController").GetComponent<HelperScript> ().SendMessage ("UpdateText", "");
			gameObject.GetComponent<Animator> ().SetBool ("isMoving", true);
		}

		if (Input.GetKeyUp(KeyCode.JoystickButton0) || Input.GetKeyUp(KeyCode.W)) {
			gameObject.GetComponent<Animator> ().SetBool ("isMoving", false);
		}*/

		currentLerpTime += Time.deltaTime;



		if (movementAllowed) {

			/*if (rotatePosX > 0) {
				GameObject.Find ("GameController").GetComponent<HelperScript> ().SendMessage ("UpdateText", "");
			}*/
			//this.transform.Rotate(0, rotatePosX * rotationSpeed, 0);

			// Generate a plane that intersects the transform's position with an upwards normal.
			Plane playerPlane = new Plane(Vector3.up, transform.position);
			// Generate a ray from the cursor position
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			// Determine the point where the cursor ray intersects the plane.
			// This will be the point that the object must look towards to be looking at the mouse.
			// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
			//   then find the point along that ray that meets that distance.  This will be the point
			//   to look at.
			float hitdist = 0.0f;
			// If the ray is parallel to the plane, Raycast will return false.
			if (playerPlane.Raycast (ray, out hitdist)) 
			{
				// Get the point along the ray that hits the calculated distance.
				Vector3 targetPoint = ray.GetPoint(hitdist);

				// Determine the target rotation.  This is the rotation if the transform looks at the target point.
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

				// Smoothly rotate towards the target point.
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
			}

			if (!isStart) {
				controlTimer -= Time.deltaTime;
				if (controlTimer < 0) {
					controls.SetActive (false);
				}
			}

			if (rotatePosX != 0.0f || rotatePostY != 0.0f) {
				if (isStart) {
					isStart = false;
				}
//				Quaternion rotation = Quaternion.LookRotation (new Vector3 (rotatePosX, 0, rotatePostY));
//				transform.rotation = rotation;
				transform.position += transform.forward * Time.deltaTime * walkSpeed;
				gameObject.GetComponent<Animator> ().SetBool ("isMoving", true);
                //Debug.Log("hello");

			} else {
				gameObject.GetComponent<Animator> ().SetBool ("isMoving", false);
			}

		}



		if (Input.GetKey(KeyCode.JoystickButton1) || Input.GetKey(KeyCode.E)) {

			/*if (spotLight.GetComponent<FlashLightScript> ().isAvailable && !movementAllowed) {
				audio.clip = Voice2;
				audio.Play ();
				movementAllowed = true;
				spotLight.SetActive (false);

				gameObject.GetComponent<CapsuleCollider> ().enabled = true;
				if (!flashLight.activeInHierarchy) {
					flashLight.SetActive (true);

				}
				GameObject.Find ("GameController").GetComponent<HelperScript> ().SendMessage ("UpdateText", "Use arrows to Left/Right!");
			}*/

			if (isMobile) {
				GameObject.FindGameObjectWithTag ("Mobile").SetActive (false);
				isMobile = false;
                hasMobileAttende = true;
				gameController.GetComponent<GameController> ().disableHelper ();
				StartCoroutine (PlayAllDialogues());
				objectives [0].GetComponent<Image> ().sprite = objectivesComplete [0];
                Debug.Log("Mobile Attended");
            }
            else if (isKey && isPoemPlayed==false)
            {
                isPoemPlayed = true;
                StartCoroutine(keySounds());
                hasKey = true;
                objectives[2].GetComponent<Image>().sprite = objectivesComplete[2];
                key.SetActive(false);
                Debug.Log("Got KEy");
            }

		}

	}

	IEnumerator PlaySounds()
	{
		audio.clip = Voice2;
		audio.Play ();
        gameController.GetComponent<GameController>().LoadSubtitle(audio.clip);
		yield return new WaitForSeconds (audio.clip.length);

		audio.clip = girlSound;
		audio.Play ();

		yield return new WaitForSeconds (audio.clip.length+3f);
		//Activate objective One.
		objectives[0].SetActive(true);
		audio.clip = maleVoice;
		audio.Play ();
        gameController.GetComponent<GameController>().LoadSubtitle(audio.clip);
		yield return new WaitForSeconds (audio.clip.length);
		blinkingMobile.GetComponent<AudioSource> ().enabled = true;
	}

	public void supriseSound()
	{
		//Play initial sounds
		StartCoroutine (PlaySounds ());
	}

	IEnumerator keySounds()
	{
		GetComponent<AudioSource>().clip = keySound;
		GetComponent<AudioSource>().Play ();
        gameController.GetComponent<GameController>().LoadSubtitle(GetComponent<AudioSource>().clip);
		yield return new WaitForSeconds (GetComponent<AudioSource>().clip.length + 0.5f);
		GetComponent<AudioSource>().clip = GhostWoman;
		GetComponent<AudioSource>().Play ();
        gameController.GetComponent<GameController>().LoadSubtitle(GetComponent<AudioSource>().clip);
	}


	IEnumerator PlayAllDialogues()
	{
		GetComponent<AudioSource>().clip = dialogues[0];
		GetComponent<AudioSource>().Play ();
        gameController.GetComponent<GameController>().LoadSubtitle(GetComponent<AudioSource>().clip);
		Debug.Log (GetComponent<AudioSource>().clip);
		//Debug.Log (GetComponent<AudioSource>().clip);

		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[1];
		GetComponent<AudioSource>().Play ();
        gameController.GetComponent<GameController>().LoadSubtitle(GetComponent<AudioSource>().clip);
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[2];
		GetComponent<AudioSource>().Play ();
        gameController.GetComponent<GameController>().LoadSubtitle(GetComponent<AudioSource>().clip);
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[3];
		GetComponent<AudioSource>().Play ();
        gameController.GetComponent<GameController>().LoadSubtitle(GetComponent<AudioSource>().clip);
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[4];
		GetComponent<AudioSource>().Play ();
        //gameController.GetComponent<GameController>().LoadSubtitle(GetComponent<AudioSource>().clip);
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[5];
		GetComponent<AudioSource>().Play ();
        gameController.GetComponent<GameController>().LoadSubtitle(GetComponent<AudioSource>().clip);
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		GetComponent<AudioSource>().clip = dialogues[6];
		GetComponent<AudioSource>().Play ();
        gameController.GetComponent<GameController>().LoadSubtitle(GetComponent<AudioSource>().clip);
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
		objectives[1].SetActive(true);
	}

	void OnTriggerStay(Collider col)
	{
		//Debug.Log (col.gameObject.tag);

//		Debug.Log (col.gameObject.tag);


		if (col.gameObject.tag == "Mobile") {
			isMobile = true;
		}

		if (col.gameObject.tag == "Key") {
			isKey = true;
			gameController.GetComponent<GameController> ().enableHelper ();
		}

        //if (col.gameObject.tag == "rightDoorCollider")
        //{
        //    if (isInitial)
        //    {
        //        gameController.GetComponent<GameController>().enableHelper();
        //    }
        //    if (Input.GetKey(KeyCode.JoystickButton1) || Input.GetKey(KeyCode.E))
        //    {
        //        col.gameObject.GetComponent<OpenDoorScript>().door.GetComponent<Animator>().SetBool("isRight", true);
        //        col.gameObject.GetComponent<OpenDoorScript>().isOpen = true;
        //        isInitial = false;
        //    }

        //    //OpenDoorToLeft(col);
        //}

        //if (col.gameObject.tag == "leftDoorCollider")
        //{
        //    if (isInitial)
        //    {
        //        gameController.GetComponent<GameController>().enableHelper();
        //    }
        //    if (Input.GetKey(KeyCode.JoystickButton1) || Input.GetKey(KeyCode.E))
        //    {
        //        col.gameObject.GetComponent<OpenDoorScript>().door.GetComponent<Animator>().SetBool("isLeft", true);
        //        col.gameObject.GetComponent<OpenDoorScript>().isOpen = true;
        //        isInitial = false;
        //    }

            //OpenDoorToRight(col);
        //}

        //Debug.Log(col.gameObject.tag);
        //if (col.gameObject.tag == "rightDoorCollider") {
        //    if (isInitial) {
        //        gameController.GetComponent<GameController> ().enableHelper ();
        //    }
        //    if (Input.GetKey (KeyCode.JoystickButton1) || Input.GetKey (KeyCode.E) || XCI.GetButton(XboxButton.B)) {
        //        col.gameObject.GetComponent<OpenDoorScript> ().door.GetComponent<Animator> ().SetBool ("isRight", true);
        //        col.gameObject.GetComponent<OpenDoorScript> ().isOpen = true;
        //        isInitial = false;
        //    }
        //}

        //if (col.gameObject.tag == "leftDoorCollider") {
        //    if (isInitial) {
        //        gameController.GetComponent<GameController> ().enableHelper ();
        //    }
        //    if (Input.GetKey (KeyCode.JoystickButton1) || Input.GetKey (KeyCode.E) || XCI.GetButton(XboxButton.B)) {
        //        col.gameObject.GetComponent<OpenDoorScript> ().door.GetComponent<Animator> ().SetBool ("isLeft", true);
        //        col.gameObject.GetComponent<OpenDoorScript> ().isOpen = true;
        //        isInitial = false;
        //    }
        //}

	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Mobile") {
			isMobile = false;
		}

		if (col.gameObject.tag == "Key") {
			isKey = false;
			gameController.GetComponent<GameController> ().disableHelper ();
		}

		if (col.gameObject.tag == "rightDoorCollider" || col.gameObject.tag == "leftDoorCollider") {
			gameController.GetComponent<GameController> ().disableHelper ();
		}

	}

	void OnCollisionEnter(Collision col)
	{
        if (col.gameObject.tag == "Walls" || col.gameObject.tag == "Doors" || col.gameObject.tag == "Furniture")
        {
            walkSpeed = 0;
        }
        
	}

    void OnCollisionExit(Collision coll)
    {
        //Debug.Log(coll.gameObject.tag);
        walkSpeed = 5;
    }

    public void OpenDoorToRight(Collider coll)
    {
        coll.gameObject.GetComponent<OpenDoorScript>().door.GetComponent<Animator>().SetBool("isRight", true);
        coll.gameObject.GetComponent<OpenDoorScript>().isOpen = true;
    }

    public void OpenDoorToLeft(Collider coll)
    {
        coll.gameObject.GetComponent<OpenDoorScript>().door.GetComponent<Animator>().SetBool("isLeft", true);
        coll.gameObject.GetComponent<OpenDoorScript>().isOpen = true;
	}

}
