using UnityEngine;
using System.Collections;



public class controler : MonoBehaviour {

	public Transform target;
	public float speed;
	float currentSpeed;
	public GameObject GameCamera;
	public Transform objectforward;

	void Start () {
		currentSpeed = speed;
		target.position = transform.position;

	}
	


	void Update() {
		float relativePosx = target.position.x - transform.position.x;
		float relativePosz = target.position.z - transform.position.z;

		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		if (x >= 1 || x <= -1 || z >= 1 || z <= -1) {

			Quaternion rotation = Quaternion.LookRotation (new Vector3 (relativePosx,0,relativePosz));
			transform.rotation = rotation;

		}


	      if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
			transform.Translate ((Vector3.forward * Time.deltaTime * currentSpeed ));
		}

		if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)){

			currentSpeed  = 0;
		}

		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S)){
			
			currentSpeed  = 0;
		}



		target.transform.rotation = GameCamera.transform.rotation;
		target.transform.eulerAngles = new Vector3 (0,target.transform.eulerAngles.y,0);


		if (Input.GetKey (KeyCode.W)&& !Input.GetKey (KeyCode.S)){
			target.Translate (Vector3.forward * Time.deltaTime * currentSpeed );
		}


		if (Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) {
			target.Translate (Vector3.right * Time.deltaTime * currentSpeed );
		}


		if (Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.W)) {
			target.Translate (Vector3.back * Time.deltaTime * currentSpeed );
			}


		

		if (Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
			target.Translate (Vector3.left * Time.deltaTime * currentSpeed );
		}

		

		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) {
			target.transform.position = objectforward.transform.position;
		
			currentSpeed  = speed;

		}
	






		//target.position = new Vector3(transform.position.x + x, 0, transform.position.z + z) ;

	
	}

	

	}



