using UnityEngine;
using System.Collections;

public enum OpeningDirection
{
    INSIDE,
    OUTSIDE
};

public enum DoorState
{
    OPEN,
    OPENING,
    CLOSE,
    CLOSEING
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
    public DoorState state = DoorState.CLOSE;

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
                //if (state == DoorState.OPENING)
                //{
                    Quaternion openingRotation = Quaternion.Euler(0, openingAngle, 0);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, openingRotation, openingTime * Time.deltaTime);
                    state = DoorState.OPENING;
                //    if (transform.localRotation.y <= -0.65f)
                //    {
                //        StartCoroutine(this.ChangingState(DoorState.OPEN));
                //    }
                //}
            }
            else
            {
                //if (state == DoorState.OPENING)
                //{
                    Quaternion openingRotation = Quaternion.Euler(0, -openingAngle, 0);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, openingRotation, openingTime * Time.deltaTime);
                    state = DoorState.OPENING;
                //    if (transform.localRotation.y >= 0.65f)
                //    {
                //        StartCoroutine(this.ChangingState(DoorState.OPEN));
                //    }
                //}
            }
        }
        else
        {
            //if (state == DoorState.CLOSEING)
            //{
                Quaternion closingRotation = Quaternion.Euler(0, closingAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, closingRotation, openingTime * Time.deltaTime);
                state = DoorState.CLOSEING;
                //if (transform.localRotation.y <= 0.05f)
                //{
                //    StartCoroutine(ChangingState(DoorState.CLOSE));
                //}
            //}
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

    //IEnumerator ChangingState(DoorState s)
    //{
    //    yield return new WaitForSeconds(0.3f);
    //    state = s;
        
    //}

    public void OpenDoorInside()
    {
        openingDirection = OpeningDirection.INSIDE;
        
        this.changeState();
        if (open)
        {
            //state = DoorState.OPENING;
            doorSoundAudioSource.Play();
        }
        else
        {
            //state = DoorState.CLOSEING;
            doorSoundAudioSource.Play();
        }
    }

    public void OpenDoorOutside()
    {
        openingDirection = OpeningDirection.OUTSIDE;
        state = DoorState.OPENING;
        this.changeState();
        if (open)
        {
            //state = DoorState.OPENING;
            doorSoundAudioSource.Play();
        }
        else
        {
            //state = DoorState.CLOSEING;
            doorSoundAudioSource.Play();
        }
    }

    public void DoorMovingState(DoorState ChangeState)
    {
        state = ChangeState;
    }
}
