using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsBackToMainMenu : MonoBehaviour
{
    public Animator anim;
    public void ClickBackBTN()
    {
        anim.SetBool("Close",true);
        anim.SetBool("Open", false);
        SceneManager.LoadScene(0);
    }
}
