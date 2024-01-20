using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene curScene;
    public DialogueType dialogPanel;
    // public CinematicController gOSwitchCanvas;

    public SwitchScreen switchScrn;
    void Start()
    {
        dialogPanel.PlayScene(curScene);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (dialogPanel.IsCompleted())
            {
                if (dialogPanel.IsLastSentence())
                {
                    curScene = curScene.nextScene;
                    dialogPanel.PlayScene(curScene);
                }
                else
                {
                    dialogPanel.PlayNextSentence();
                    if (dialogPanel.IsLastSentence())
                    {
                        switchScrn.SwitchSceneName();
                    }
                }

            }
            
        }
    }
}
