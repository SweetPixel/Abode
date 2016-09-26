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
        Debug.DrawLine(origin.position, targetFront.position, Color.black);
    }
}