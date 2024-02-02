using UnityEngine;

public class GameControllerForCutScenes1 : MonoBehaviour
{
    public StoryScene curScene;
    public DialogueType dialogPanel;
    public SwitchScreen switchScrn;
    private int sentenceIDX = -1;
    
    void Start()
    {
        dialogPanel.PlayScene(curScene);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Debug.Log(sentenceIDX);
            if (dialogPanel.IsCompleted())
            {
                if (dialogPanel.IsLastSentence())
                {
                    dialogPanel.PlayScene(curScene);
                }
                else
                {
                    //  ++sentenceIDX;
                    dialogPanel.PlayNextSentence();
                }

                if (++sentenceIDX == curScene.sentences.Count - 1)
                {
                    switchScrn.SwitchSceneName();
                    AudioManager.Instance.sfxSource.Pause();
                }
            }
 
        }
    }
}

