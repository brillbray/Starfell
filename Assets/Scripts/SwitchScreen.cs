using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScreen : MonoBehaviour
{
    //public GameObject cutScenes;
    //public GameObject moveScenes;
    public string sceneName;
    public void SwitchToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SwitchSceneName()
    {
        SceneManager.LoadScene(sceneName);
    }

    //public void SwitchNextGO()
    //{
    //    cutScenes.SetActive(false);
    //    moveScenes.SetActive(true);
    //    Debug.Log("MASUK SWITCH");  
    //}
    public void Quit()
    {
        Application.Quit();
    }

}