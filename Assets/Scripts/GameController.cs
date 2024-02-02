using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene curScene;
    public DialogueType dialogPanel;
    public NPC npc;
    public GameObject showingPressEtoExitDialogue;
    public SwitchScreen switchScrn;
    private int sentenceIDX = -1;
    void Start()
    {
        dialogPanel.PlayScene(curScene);
    }

    void Update()
    {
        if(npc.isInDialog)
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
                        ++sentenceIDX;
                        dialogPanel.PlayNextSentence();
                        if(dialogPanel.IsLastSentence())
                        {
                            dialogPanel.DisableClick();
                            showingPressEtoExitDialogue.SetActive(true);
                        }
                    }
                }
            }
        }else{
            AudioManager.Instance.mscSource.volume = 0.2f;
        }
    }
}
