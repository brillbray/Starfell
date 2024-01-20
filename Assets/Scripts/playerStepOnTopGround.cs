using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStepOnTopGround : MonoBehaviour
{
    public SwitchScreen switchScreen;

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           switchScreen.SwitchToNextScene();
        }
    }   

}
