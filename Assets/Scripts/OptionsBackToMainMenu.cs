using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsBackToMainMenu : MonoBehaviour
{
    public void ClickBackBTN()
    {
        SceneManager.LoadScene(0);
    }
}
