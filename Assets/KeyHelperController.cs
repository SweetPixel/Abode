using UnityEngine;
using System.Collections;

public class KeyHelperController : MonoBehaviour
{
    public GameObject keyHelperCanvas;
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            keyHelperCanvas.SetActive(true);
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            keyHelperCanvas.SetActive(false);
        }
    }
}
