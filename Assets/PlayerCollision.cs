using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
    public float pushPower = 2.0F;
<<<<<<< HEAD

    public Light light;
    public LayerMask mask1;
    public LayerMask mask2;
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Walls" || col.gameObject.tag == "Doors")
        {
            light.cullingMask = mask1;
            //Debug.Log("Walls");
        }

    }

    void OnCollisionExit(Collision coll)
    {
        light.cullingMask = mask2;
        //Debug.Log("Walls exit");
    }
=======
>>>>>>> imrankhanswati-Abode-Fisrt-Person-View

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }

}
