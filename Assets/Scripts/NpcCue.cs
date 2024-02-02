using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCue : MonoBehaviour
{
    public GameObject triggered;
    public GameObject cue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == triggered)
        {
            cue.gameObject.SetActive(true);
        }
        else
        {
            cue.gameObject.SetActive(false);
        }
    }
}
