using UnityEngine;
using System.Collections;
using System;

public class DoorOpen : MonoBehaviour
{
    public Transform origin;
    public Transform targetFront;
    public float rayLenght;
    private Ray DoorOpenerRay;
    private RaycastHit hit;

    private Collider openDoorRef;
    private DoorState doorCurrentState;

    void Start()
    {
        DoorOpenerRay = new Ray(origin.position, targetFront.position);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Linecast(origin.position, targetFront.position, out hit))
            {
                if (hit.collider.tag == "DoorInsideCollider")
                {
                    hit.collider.transform.parent.transform.parent.GetComponent<DoorController>().OpenDoorOutside();
                }
                else if (hit.collider.tag == "DoorOutsideCollider")
                {
                    hit.collider.transform.transform.parent.parent.GetComponent<DoorController>().OpenDoorInside();
                }
            }
        }
        //if (Physics.Linecast(origin.position, targetFront.position, out hit))
        //{
        //    if (hit.collider.tag == "rightDoorCollider")
        //    {

        //        gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().OpenDoorToRight(hit.collider);
        //        openDoorRef = hit.collider;
        //        doorCurrentState = DoorState.OPEN;
        //    }
        //    else if (hit.collider.tag == "leftDoorCollider")
        //    {
        //        gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().OpenDoorToLeft(hit.collider);
        //        openDoorRef = hit.collider;
        //        doorCurrentState = DoorState.OPEN;
        //    }
        //}
        Debug.DrawLine(origin.position, targetFront.position, Color.black);
    }
    
		
}