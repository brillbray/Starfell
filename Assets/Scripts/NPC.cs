using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject cue;
    public DialogueType dialogueTyping;
    public StoryScene curScene;

    public float wordSpeed;
    public bool playerCloseNPC;
    private bool isInDialog;

    void Update()
    {
        if (playerCloseNPC && Input.GetKeyDown(KeyCode.E))
        {
            if (isInDialog)
            {
                ExitDialog();
            }
            else
            {
                EnterDialog();
            }
        }
    }

    private void EnterDialog()
    {
        dialogPanel.SetActive(true);
        dialogueTyping.PlayScene(curScene);
        FreezePlayerMovement();
        isInDialog = true;
    }

    private void ExitDialog()
    {
        dialogPanel.SetActive(false);
        UnfreezePlayerMovement();
        isInDialog = false;
    }
  
    private void FreezePlayerMovement()
    {
        MCMovement mcMovement = FindFirstObjectByType<MCMovement>();

        if (mcMovement != null)
        {
            mcMovement.SetMovementEnabled(false); 
        }
    }

    private void UnfreezePlayerMovement()
    {
        MCMovement mcMovement = FindFirstObjectByType<MCMovement>();

        if (mcMovement != null)
        {
            mcMovement.SetMovementEnabled(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
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
