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

    public GameController gameController;

    void Start()
    {
        DoorOpenerRay = new Ray(origin.position, targetFront.position);
    }

    void Update()
    {
        if (Physics.Linecast(origin.position, targetFront.position, out hit))
        {
            if (hit.collider.tag == "DoorInsideCollider")
            {
                gameController.GetComponent<GameController>().enableHelper();
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.parent.transform.parent.GetComponent<DoorController>().OpenDoorOutside();
                }
            }
            else if (hit.collider.tag == "DoorOutsideCollider")
            {
                gameController.GetComponent<GameController>().enableHelper();
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.transform.parent.parent.GetComponent<DoorController>().OpenDoorInside();
                }
            }
            else
            {
                if (gameController.isHelperEnabled && gameController.isHelperEnabledByOther == false)
                {
                    gameController.GetComponent<GameController>().disableHelper();
                }
            }
        }
        else
        {
            if (gameController.isHelperEnabled && gameController.isHelperEnabledByOther == false)
            {
                gameController.GetComponent<GameController>().disableHelper();
            }
        }

        Debug.DrawLine(origin.position, targetFront.position, Color.black);
    }
}
