using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAudioOptions : MonoBehaviour
{
    public GameObject AudioOptionsOverlay;

    public void OpenOptions()
    {
        if(AudioOptionsOverlay != null)
        {
            AudioOptionsOverlay.SetActive(true);
        }
    }
}
