using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class attackClicked : MonoBehaviour
{
    // public 
    public GameObject mcObj;
    public Animator attackAnimator;
    public bool click = false;
    void Start()
    {
        attackAnimator = mcObj.GetComponent<Animator>();
         if (attackAnimator == null)
        {
            Debug.LogError("Animator component not found on " + mcObj.name);
        }
    }

    
    void Update()
    {   
        HandleInput();
    }   

    void HandleInput()
    {
        if(attackAnimator != null)
        {
            if (Input.GetKey(KeyCode.E))
            {
                click = true;
                Attack();
            
            }
            else
            {
                click = false;
                Idle();
            }
        }
        
        
    }

    void Attack()
    {
        attackAnimator.SetBool("Attack", true);
        attackAnimator.SetBool("Idle",false);
    }

    void Idle()
    {
        attackAnimator.SetBool("Attack",false);
        attackAnimator.SetBool("Idle",true);
    }

}
