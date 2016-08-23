using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour 
{
    public Transform origin;
    public Transform target;
    public float rayLenght;
    private Ray DoorOpenerRay;
    private RaycastHit hit;

	void Start () 
    {
        DoorOpenerRay = new Ray(origin.position, target.position);
	}

	void Update () 
    {
	    if(Physics.Linecast(origin.position,target.position,out hit))
        {
            if (hit.collider.tag == "rightDoorCollider")
            {

                gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().OpenDoorToRight(hit.collider);
            }
            if (hit.collider.tag == "leftDoorCollider")
            {
                gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().OpenDoorToLeft(hit.collider);
               
            }
            //Debug.Log(hit.collider.tag);
        }
        Debug.DrawLine(origin.position, target.position,Color.green);
	}
}
