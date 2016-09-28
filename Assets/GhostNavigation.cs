using UnityEngine;
using System.Collections;

public class GhostNavigation : MonoBehaviour 
{
    public Transform Target;
    private NavMeshAgent navMesh;
    private float FollwingDuration;
    private float playerOutOfRangeDuration;
    private bool isPlayerInRange = false;
    public float totalFollwingDuration;
	void Start () {
        navMesh = GetComponent<NavMeshAgent>();
	}

	void FixedUpdate () 
    {
        if (Target != null)
        {
            navMesh.destination = Target.position;
            if (isPlayerInRange==false)
            {
                if (FollwingDuration>0)
                {
                    FollwingDuration -= Time.deltaTime;
                }
                else
                {
                    Target = null;
                    isPlayerInRange = true;
                    FollwingDuration = totalFollwingDuration;
                }
            }
        }
        

	}


    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Target = coll.gameObject.transform;
            isPlayerInRange = true;
            FollwingDuration = totalFollwingDuration;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }
}
