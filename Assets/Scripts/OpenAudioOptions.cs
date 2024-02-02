using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAudioOptions : MonoBehaviour
{
    public GameObject AudioOptionsOverlay;
    public Animator anim;

    public void OpenOptions()
    {
        if(AudioOptionsOverlay != null && anim != null)
        {
            AudioOptionsOverlay.SetActive(true);
            anim.SetBool("Open", true);
            anim.SetBool("Close", false);
        }
    }
}
