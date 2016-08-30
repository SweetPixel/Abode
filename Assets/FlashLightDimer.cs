using UnityEngine;
using System.Collections;

public class FlashLightDimer : MonoBehaviour {

    public Transform startPos;
    public Transform targetPos;
    public Light playerFlashLight;
    public float lightStrenght;
    private RaycastHit hit;
    float tmpResult;
    float tempRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Physics.Linecast(startPos.position, targetPos.position, out hit))
        {
            
            if (hit.collider.tag == "Walls")
            {
                tempRange=lightStrenght * hit.distance;
                if (tempRange < 13)
                {
                    if (tempRange - 3 > 1)
                    {
                        playerFlashLight.range = tempRange - 4;
                    }
                    else
                    {
                        playerFlashLight.range = tempRange;
                    }
                    tmpResult = 10 - hit.distance;
                    if (playerFlashLight.intensity < tmpResult / 3)
                    {
                        playerFlashLight.intensity = tmpResult/2;
                    }
                }
            }
        }
        else
        {

            playerFlashLight.range = Mathf.Lerp(playerFlashLight.range, 13, 0.5f);
            playerFlashLight.intensity = Mathf.Lerp(playerFlashLight.intensity, 1.2f, 0.5f);
            
        }
        //Debug.DrawLine(startPos.position, targetPos.position, Color.cyan);
	}
}
