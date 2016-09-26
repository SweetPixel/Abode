using UnityEngine;
using System.Collections;

public enum OpeningDirection
{
    INSIDE,
    OUTSIDE
};
public class DoorController : MonoBehaviour {

    public bool open = false;
    public float openingAngle = 90;
    public float closingAngle = 0;
    public float openingTime = 2f;
    public OpeningDirection openingDirection;
    public bool AutoClose = false;
    public float autocloseIntervalTime = 1f;
    public AudioSource doorSoundAudioSource;

	// Use this for initialization
	void Start () {
	
	}

 
	// Update is called once per frame
    void Update()
    {
        if (open)
        {
            if (openingDirection == OpeningDirection.INSIDE)
            {
                Quaternion openingRotation = Quaternion.Euler(0, openingAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, openingRotation, openingTime * Time.deltaTime);
            }
            else
            {
                Quaternion openingRotation = Quaternion.Euler(0, -openingAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, openingRotation, openingTime * Time.deltaTime);
            }
        }
        else
        {
            Quaternion closingRotation = Quaternion.Euler(0, closingAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, closingRotation, openingTime*Time.deltaTime);
        }
    }

    public void changeState()
    {
        open = !open;
        if (AutoClose)
        {
            StartCoroutine(AutoClosingDoor());
        }
    }

    IEnumerator AutoClosingDoor()
    {
        yield return new WaitForSeconds(autocloseIntervalTime);
        open = false;
    }

    public void OpenDoorInside()
    {
        openingDirection = OpeningDirection.INSIDE;
        this.changeState();
        if (open)
        {
            doorSoundAudioSource.Play();
        }
        else
        {
            doorSoundAudioSource.Play();
        }
    }

    public void OpenDoorOutside()
    {
        openingDirection = OpeningDirection.OUTSIDE;
        this.changeState();
        if (open)
        {
            doorSoundAudioSource.Play();
        }
        else
        {
            doorSoundAudioSource.Play();
        }
    }
}
