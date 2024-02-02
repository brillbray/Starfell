using UnityEngine;

public class GameControllerForScene3 : MonoBehaviour
{
    public StoryScene curScene;
    public DialogueType dialogPanel;
    public SwitchScreen switchScrn;
    private int sentenceIDX = -1;

    void Start()
    {
        dialogPanel.PlayScene(curScene);
        AudioManager.Instance.PlayMusic("IntroMusic");
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
                }
                else
                {
                    dialogPanel.PlayNextSentence();
                }

                if(++sentenceIDX == curScene.sentences.Count - 1)
                {
                    switchScrn.SwitchSceneName();
                }       
            }
       
        }
    }
}