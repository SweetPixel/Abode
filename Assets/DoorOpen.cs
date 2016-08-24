using UnityEngine;
using System.Collections;

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
        if (Physics.Linecast(origin.position, targetFront.position, out hit))
        {
            if (hit.collider.tag == "rightDoorCollider")
            {

                gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().OpenDoorToRight(hit.collider);
                openDoorRef = hit.collider;
                doorCurrentState = DoorState.OPEN;
            }
            else if (hit.collider.tag == "leftDoorCollider")
            {
                gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().OpenDoorToLeft(hit.collider);
                openDoorRef = hit.collider;
                doorCurrentState = DoorState.OPEN;
            }
        }
        Debug.DrawLine(origin.position, targetFront.position, Color.black);
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "leftDoorCollider" || coll.tag == "leftDoorCollider")
        {
            if (doorCurrentState == DoorState.OPEN)
            {
                openDoorRef.gameObject.GetComponent<OpenDoorScript>().enableDoorClose = true;
                openDoorRef = null;
                doorCurrentState = DoorState.CLOSE;
                Debug.Log("close Door");
            }
        }
    }


}