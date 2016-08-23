using UnityEngine;
using System.Collections;

public class PauseMenueController : MonoBehaviour
{
    public GameObject gamePauseMenue;
    public GameObject CanvasTohid;
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePauseMenue.activeSelf)
            {
                Time.timeScale = 1;
                gamePauseMenue.SetActive(false);
                //CanvasTohid.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                gamePauseMenue.SetActive(true);
                //CanvasTohid.SetActive(false);
            }
            
        }
	}

    public void Resume()
    {
        Time.timeScale = 1;
        gamePauseMenue.SetActive(false);
        //CanvasTohid.SetActive(true);
    }

    public void Setting()
    {

    }

    public void MainMenue()
    {

    }
}
