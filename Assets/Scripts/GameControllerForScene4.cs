using System.Collections;
using UnityEngine;

public class GameControllerForScene4 : MonoBehaviour
{
    public StoryScene curScene;
    public DialogueType dialogPanel;
    public SwitchScreen switchScrn;
    private int sentenceIDX = 0;
    public GameObject GameOver;
    public Animator animGameOver;
    public GameObject canvasDialogPanel;
    void Start()
    {
        dialogPanel.PlayScene(curScene);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (dialogPanel.IsCompleted())
            {
                if (dialogPanel.IsLastSentence())
                {
                    dialogPanel.PlayScene(curScene);
                    if(sentenceIDX++ == curScene.sentences.Count - 1)
                    {
                        dialogPanel.DisableClick();
                        GameOver.SetActive(true);
                        animGameOver.SetTrigger("Credit");
                        canvasDialogPanel.SetActive(false);
                        StartCoroutine(DelayForCredit());
                    }   
                }
                else
                {
                    dialogPanel.PlayNextSentence();
                    if(sentenceIDX++ == curScene.sentences.Count - 1)
                    {
                        dialogPanel.DisableClick();
                        GameOver.SetActive(true);
                        animGameOver.SetTrigger("Credit");
                        canvasDialogPanel.SetActive(false);
                        StartCoroutine(DelayForCredit());
                    }   
                }
            }
   
        }else{
            AudioManager.Instance.mscSource.volume = 0.2f;
        }
    }
    IEnumerator DelayForCredit(){
        yield return new WaitForSeconds(3f);
        switchScrn.SwitchSceneName();
    }
}