using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour {
    [Header("Audio Objects")]
    public static GameObject[] ObjectsHavingAudio;


    //subtitle relvent vars....
    [Header("Subtitles")]
    public AudioSubtitle[] audioSub;
    public Text subTitleText;

	private GameObject helper;

	// Use this for initialization

    void Awake()
    {
        this.LoadSubtitle(this.gameObject.GetComponent<AudioSource>().clip);
    }
	void Start () {
		helper = GameObject.Find ("HelpingText");
		//helper.SetActive (false);
	}
	
	// Update is called once per frame
	

	public void enableHelper()
	{
		helper.SetActive (true);
	}

	public void disableHelper()
	{
		helper.SetActive (false);
	}



    public static void EnableAllAudios()
    {
        for (int i = 0; i < ObjectsHavingAudio.Length; i++)
        {
            ObjectsHavingAudio[i].GetComponent<AudioSource>().UnPause();
        }
    }

    public static void DisableAllAudios()
    {
        for (int i = 0; i < ObjectsHavingAudio.Length; i++)
        {
            ObjectsHavingAudio[i].GetComponent<AudioSource>().Pause();
        }
    }


    //Subtitle realted funtions....

    AudioSubtitle ClipElementFromAudioSubtitleArray;
    AudioClip clip;
    public static bool showSubtitle = false;
    private float ShownTime;
    private float MaxTimeForSub;
    private float subTime;
    private int subID=0;
    private string subText;
    private bool isFirstText = false;


    void Update()
    {
        if (showSubtitle)
        {

            if (MaxTimeForSub < ShownTime)
            {
                //RemTime += Time.deltaTime;
                //subTitleText.text = subText;
                //isFirstText = false;
                ShownTime = 0;
                this.LoadNextText(ClipElementFromAudioSubtitleArray, subID);
                subTitleText.text = subText;
            }
            else
            {
                ShownTime += Time.deltaTime;
            }
        }
    }

    public void LoadSubtitle(AudioClip clip)
    {
        subID = 0;
        ClipElementFromAudioSubtitleArray = GetElement(clip);
        this.LoadNextText(ClipElementFromAudioSubtitleArray, subID);
        showSubtitle = true;
        subTitleText.gameObject.SetActive(true);
        subTitleText.text = subText;
        ShownTime=0;
    }

    public void LoadNextText(AudioSubtitle audioSub,int currentTextID)
    {
        currentTextID += 1;
        try
        {
            if (currentTextID <= audioSub.textForAudio.Length)
            {
                foreach (Subtitles sub in audioSub.textForAudio)
                {
                    if (sub.subid == currentTextID)
                    {
                        subID = currentTextID;
                        subText = sub.SubText;
                        MaxTimeForSub = sub.timeForText;
                    }
                }
            }
            else
            {
                subID = 0;
                subTitleText.gameObject.SetActive(false);
            }
        }
        catch (NullReferenceException e)
        { 
            
        }
    }

    public AudioSubtitle GetElement(AudioClip clip)
    {
        foreach (AudioSubtitle audio in audioSub)
        {
            if (clip == audio.audio)
            {
                return audio;
            }
        }
        return null;
    }


}

[System.Serializable]
public class AudioSubtitle
{
    public AudioClip audio;
    public int audioID;
    public Subtitles[] textForAudio;
    private bool showSub = false;
}

[System.Serializable]
public class Subtitles
{
    public string SubText;
    public int subid;
    public float timeForText;
}
