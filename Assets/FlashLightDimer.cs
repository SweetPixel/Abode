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
            
            if (hit.collider.tag == "Walls")
            {
                tempRange=lightStrenght * hit.distance;
                if (tempRange < 15)
                {
                    if (tempRange > 2.5)
                    {
                            playerFlashLight.range = tempRange - 2;
                    }
                    else
                    {
                        playerFlashLight.range = tempRange;
                    }
                    tmpResult = 10 - hit.distance;
                    if (playerFlashLight.intensity < tmpResult / 3)
                    {
                        if (tmpResult / 1.7 > 2)
                        {
                            playerFlashLight.intensity = tmpResult / 1.7f;
                            Debug.Log("done");
                        }
                        else
                        {
                            playerFlashLight.intensity = 2;
                        }
                    }
                }
            }
            else
            {

                playerFlashLight.range = Mathf.Lerp(playerFlashLight.range, 15, 0.5f);
                playerFlashLight.intensity = Mathf.Lerp(playerFlashLight.intensity, 2f, 0.3f);
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
                playerFlashLight.spotAngle = 65;
            }
        }
        else if (Physics.Linecast(startPos.position, targetLeft.position, out hit))
        {
            if (hit.collider.tag == "Walls")
            {
                playerFlashLight.spotAngle = 65;
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
