using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScreen : MonoBehaviour
{
    public string sceneName;
    public void SwitchToNextScene()
    {
   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SwitchSceneName()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

}