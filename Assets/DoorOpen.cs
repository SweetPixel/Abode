using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour 
{
    public Transform origin;
    public float rayLenght;
    private Ray DoorOpenerRay;
    private RaycastHit hit;

	void Start () 
    {
        DoorOpenerRay = new Ray(origin.position, Vector3.forward);
	}

	void Update () 
    {
	    if(Physics.Raycast(DoorOpenerRay,out hit,rayLenght))
        {
            if (hit.collider.tag == "Door")
            {
                Debug.Log("Door detected...");
            }
        }
        Debug.DrawLine(origin.position, new Vector3(origin.position.x, origin.position.y, origin.position.z+rayLenght),Color.green);
	}
}
