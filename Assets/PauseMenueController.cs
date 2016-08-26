using UnityEngine;
using System.Collections;

public class PauseMenueController : MonoBehaviour
{
    public GameObject gamePauseMenue;
    public GameObject CanvasTohid;
    public GameObject[] AudioSourceContainingObjects;
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePauseMenue.activeSelf)
            {
                Time.timeScale = 1;
                gamePauseMenue.SetActive(false);
                EnableAudio();
                //CanvasTohid.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                gamePauseMenue.SetActive(true);
                DisableAudio();
                //CanvasTohid.SetActive(false);
            }
            
        }
	}

    public void Resume()
    {
        Time.timeScale = 1;
        gamePauseMenue.SetActive(false);
        EnableAudio();
        //CanvasTohid.SetActive(true);
    }

    public void Setting()
    {

    }

    public void MainMenue()
    {

    }

    void EnableAudio()
    {
        for (int i = 0; i < AudioSourceContainingObjects.Length; i++)
        {
            AudioSourceContainingObjects[i].GetComponent<AudioSource>().UnPause();
        }
    }

    void DisableAudio()
    {
        for (int i = 0; i < AudioSourceContainingObjects.Length; i++)
        {
            AudioSourceContainingObjects[i].GetComponent<AudioSource>().Pause();
        }
    }
}
