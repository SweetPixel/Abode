using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
    public float pushPower = 2.0F;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if (hit.gameObject.tag == "DoorInsideCollider")
        //{
        //    if (hit.transform.parent.transform.parent.gameObject.GetComponent<DoorController>().state == DoorState.CLOSEING)
        //    {
        //        Debug.Log(hit.gameObject.tag);
        //        hit.transform.parent.transform.parent.gameObject.GetComponent<DoorController>().DoorMovingState(DoorState.OPENING);
        //        hit.transform.parent.transform.parent.gameObject.GetComponent<DoorController>().changeState();
        //    }
        //}

        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }
}
