using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
    public Light light;
    public LayerMask mask1;
    public LayerMask mask2;
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Walls" || col.gameObject.tag == "Doors")
        {
            light.cullingMask = mask1;
            Debug.Log("Walls");
        }

    }

    void OnCollisionExit(Collision coll)
    {
        light.cullingMask = mask2;
        Debug.Log("Walls exit");
    }

}
