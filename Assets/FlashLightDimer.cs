using UnityEngine;
using System.Collections;

public class FlashLightDimer : MonoBehaviour {

    public Transform startPos;
    public Transform targetPos;
    public Transform targetLeft;
    public Transform targetRight;
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
            
            if (hit.collider.tag == "Walls"||hit.collider.tag=="Doors")
            {
                tempRange=lightStrenght * hit.distance;
                if (tempRange < 15)
                {
                    if (tempRange > 5)
                    {
                            playerFlashLight.range = tempRange - 2;
                    }
                    else
                    {
                        playerFlashLight.range = tempRange;
                    }
                    tmpResult = 10 - hit.distance;
                    if (playerFlashLight.intensity < tmpResult / 2.5)
                    {
                        if (tmpResult / 1.7 > 1.5)
                        {
                            playerFlashLight.intensity = tmpResult / 1.6f;
                        }
                        else
                        {
                            playerFlashLight.intensity = 1.5f;
                        }
                    }
                }
            }
            else
            {

                playerFlashLight.range = Mathf.Lerp(playerFlashLight.range, 15, 0.5f);
                playerFlashLight.intensity = Mathf.Lerp(playerFlashLight.intensity, 1.5f, 0.3f);
            }
        }
        else
        {

            playerFlashLight.range = Mathf.Lerp(playerFlashLight.range, 13, 0.5f);
            playerFlashLight.intensity = Mathf.Lerp(playerFlashLight.intensity, 1.2f, 0.3f);
        }
        if(Physics.Linecast(startPos.position,targetLeft.position,out hit))
        {
            if (hit.collider.tag == "Walls")
            {
                playerFlashLight.spotAngle = 70;
            }
        }
        else if (Physics.Linecast(startPos.position, targetLeft.position, out hit))
        {
            if (hit.collider.tag == "Walls")
            {
                playerFlashLight.spotAngle = 70;
            }
        }
        else
        {
            playerFlashLight.spotAngle = Mathf.Lerp(70, 80, 0.2f);
        }
        Debug.DrawLine(startPos.position, targetPos.position, Color.cyan);
        Debug.DrawLine(startPos.position, targetLeft.position, Color.cyan);
        Debug.DrawLine(startPos.position, targetRight.position, Color.cyan);
	}
}
