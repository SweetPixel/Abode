using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDetector : MonoBehaviour {

	public Transform target;
	public bool spotted = true;
	public float speed = 2.5f;
	public Transform player;

	private float duration = 10f;
	private bool timerStart = false;


	public GameObject restart;
	private bool isRestart = false;
	public  float restartTimer = 1.5f;

	public GameObject flashLight;
    private float tempSpeed;//use to recover speed over again when it get 0 on collision

	// Use this for initialization
	void Start () {
        tempSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.DrawLine (transform.position, target.position, Color.blue);
		//spotted = Physics2D.Linecast (transform.position, target.position, 1 << LayerMask.NameToLayer ("Player"));
		if (spotted && duration > 0) {
			
			float step = speed * Time.deltaTime;
			//gameObject.transform.LookAt (player.position);
			if (player != null) {
				gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector3 (player.position.x, gameObject.transform.position.y, player.position.z), step);
				transform.LookAt (new Vector3 (player.position.x, gameObject.transform.position.y, player.position.z));
			}
		}

		if (timerStart && duration > 0) {
			duration = duration - Time.deltaTime;
		}

		if (isRestart) {
			restartTimer -= Time.deltaTime;
			if (restartTimer < 0) {
				Application.LoadLevelAsync ("Gameplay");
			}
		}

	}

	void OnTriggerEnter(Collider col)
	{
<<<<<<< HEAD
//		Debug.Log (col.gameObject.name);
=======
		//Debug.Log (col.gameObject.name);
>>>>>>> origin/master
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
		//Debug.Log (col.gameObject.name);
		if (col.gameObject.name == "Player") {
			Instantiate (flashLight, col.gameObject.transform.position, gameObject.transform.rotation);
			col.gameObject.GetComponent<AudioSource> ().enabled = false;
			Destroy (col.gameObject);

			GameObject.Find ("Panel").GetComponent<Image> ().color = Color.white;
			GameObject.Find ("Panel").GetComponent<FadeInScript> ().enabled = false;
			GameObject.Find ("Panel").GetComponent<FadeOutScript> ().enabled = true;

			//restart.SetActive (true);
			isRestart = true;
		}
        
	}
}
