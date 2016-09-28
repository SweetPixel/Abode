using UnityEngine;
using System.Collections;

public class FPSSetting : MonoBehaviour
{
    public int targetFrameRate;
    public bool isVSynced;
	void Start () {
        Application.targetFrameRate = targetFrameRate;
        if (!isVSynced)
        {
            QualitySettings.vSyncCount = 0;
        }
	}
	void Update () {
        if (Application.targetFrameRate==targetFrameRate)
        {
            return;
        }
        else
        {
            Application.targetFrameRate = targetFrameRate;
            
        }
        if (isVSynced)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Debug.Log("frameRate");
	}
}
