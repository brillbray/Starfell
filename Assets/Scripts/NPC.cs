using UnityEngine;
public class NPC : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject cue;
    public DialogueType dialogueTyping;
    public StoryScene curScene;
    public float wordSpeed;
    public bool playerCloseNPC;
    public bool isInDialog;
    

    void Update()
    {
        if (playerCloseNPC && Input.GetKeyDown(KeyCode.E))
        {
            if (isInDialog)
            {
                ExitDialog();
                AudioManager.Instance.sfxSource.Pause();
                dialogueTyping.EnableClick();
            }
            else
            {
                AudioManager.Instance.sfxSource.UnPause();
                EnterDialog();
            }
        }else if(!playerCloseNPC && isInDialog){
            ExitDialog();
            AudioManager.Instance.sfxSource.Pause();
        }
    }

    public void EnterDialog()
    {
        dialogPanel.SetActive(true);
        dialogueTyping.PlayScene(curScene);
        FreezePlayerMovement();
        isInDialog = true;
    }

    public void ExitDialog()
    {
        dialogPanel.SetActive(false);
        UnfreezePlayerMovement();
        isInDialog = false;
    }
  
    private void FreezePlayerMovement()
    {
        McMovement mcMovement = FindFirstObjectByType<McMovement>();

        if (mcMovement != null)
        {
            mcMovement.SetMovementEnabled(false); 
        }
    }

    private void UnfreezePlayerMovement()
    {
        McMovement mcMovement = FindFirstObjectByType<McMovement>();

        if (mcMovement != null)
        {
            mcMovement.SetMovementEnabled(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCloseNPC = true;
            cue.SetActive(true);
        }
    }   

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            playerCloseNPC = false;
            cue.SetActive(false);
            dialogPanel.SetActive(false);
        }
    }
}
