using UnityEngine;
using System.Collections;

public class PlayerDetector : MonoBehaviour {

	public Transform target;
	public bool spotted = true;
	public float speed = 2.5f;
	public Transform player;

	private float duration = 10f;
	private bool timerStart = false;


	public GameObject restart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.DrawLine (transform.position, target.position, Color.blue);
		//spotted = Physics2D.Linecast (transform.position, target.position, 1 << LayerMask.NameToLayer ("Player"));
		if (spotted && duration > 0) {
			
			float step = speed * Time.deltaTime;
			//gameObject.transform.LookAt (player.position);
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (player.position.x, gameObject.transform.position.y, player.position.z), step);
			transform.LookAt (new Vector3 (player.position.x, gameObject.transform.position.y, player.position.z));
		}

		if (timerStart && duration > 0) {
			duration = duration - Time.deltaTime;
		}

	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log (col.gameObject.name);
		/*if (col.gameObject.name == "lightRange") {
			spotted = false;
			//Destroy (gameObject);
		}*/

		if (col.gameObject.name == "Player") {
			spotted = true;
			duration = 10f;
		}

	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.name == "Player") {
			timerStart = true;
		}

	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log (col.gameObject.name);
		if (col.gameObject.name == "Player") {
			Destroy (col.gameObject);
			restart.SetActive (true);
		}
	}

}
