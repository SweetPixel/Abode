using UnityEngine;
using System.Collections;

public class ThunderFlickering : MonoBehaviour {

    public float waitTime;
    public float flickeringTime;
    public float deltaFlickeringTime;
    public Color[] colorsArray;

    public float flickeringIntensity;
    public float flickeringRange;
    public Color flickeringColor;

    public Light thuderLight;

	// Use this for initialization
	void Start () {
        this.SetWaitTime();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        if (waitTime <= 0)
        {
           
            if (flickeringTime > 0)
            {
                flickeringTime -= Time.deltaTime;
                if (deltaFlickeringTime <= 0)
                {
                    deltaFlickeringTime = Random.Range(0.035f, 0.06f);
                    flickeringRange = Random.Range(10, 40);
                    flickeringColor = colorsArray[Random.Range(0, colorsArray.Length)];
                    thuderLight.range = flickeringRange;
                    thuderLight.enabled = !thuderLight.enabled;
                }
                else
                {
                    deltaFlickeringTime -= Time.deltaTime;
                }
               
            }
            else
            {
                thuderLight.enabled = false;
                this.SetWaitTime();
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
            //thuderLight.enabled = false;

        }
    }
    void SetWaitTime()
    {
        waitTime = Random.Range(3, 5);
        flickeringTime = Random.Range(0.8f, 1.7f);
    }
}
