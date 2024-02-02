using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McMoveAnimation : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(anim != null)
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("LeftMove", true);
                anim.SetBool("RightMove", false);
                anim.SetBool("FrontMove", false);
                anim.SetBool("BackMove", false);
            }
            else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
                anim.SetBool("RightMove", true);
                anim.SetBool("LeftMove", false);
                anim.SetBool("FrontMove", false);
                anim.SetBool("BackMove", false);
            }
            else if(Input.GetKey(KeyCode.S ) || Input.GetKey(KeyCode.DownArrow)){
                anim.SetBool("FrontMove", true);
                anim.SetBool("RightMove", false);
                anim.SetBool("LeftMove",false);
                anim.SetBool("BackMove", false);
            }
            else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
                anim.SetBool("BackMove", true);
                anim.SetBool("RightMove", false);
                anim.SetBool("LeftMove", false);
                anim.SetBool("FrontMove", false);
            }
            else
            {
                anim.SetBool("LeftMove", false);
                anim.SetBool("RightMove", false);
                anim.SetBool("FrontMove", false);
                anim.SetBool("BackMove", false);
            }
        }
        
    }
}
