using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McAnimationController : MonoBehaviour
{
    public GameObject mcObj;
    public Animator attackAnimator;

    void Start()
    {
        attackAnimator = mcObj.GetComponent<Animator>();
    }

    public void Attack(){
           attackAnimator.SetBool("Attack", true);
           attackAnimator.SetBool("Idle",false);
    }

    public void Idle(){
       attackAnimator.SetBool("Attack", false);
        attackAnimator.SetBool("Idle",true);
    }


    

}
