using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicController : MonoBehaviour
{
    public GameObject curCanvas;
    public GameObject switchCanvas;
    public bool isSwitch = false;

    public void SwitchingCanvas()
    {
        if (!isSwitch)
        {
            //Debug.Log("masuk if");
            switchCanvas.SetActive(false);
        }
        else
        { 
            //Debug.Log("masuk else");
            switchCanvas.SetActive(true);
            curCanvas.SetActive(false);
        }
        isSwitch = !isSwitch;
    }
}
