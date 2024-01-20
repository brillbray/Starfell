using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTextManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogueText;
    public string dialogue;
    private int index;

    public float wordSpeed;

    //void Start()
    //{
    //    StartCoroutine(TypingText());
    //}

   private IEnumerator TypingText()
    {
        //foreach (char ltr in dialogue[index].ToCharArray())
        //{
        //    dialogueText.text += dialogue[index];
        //    yield return new WaitForSeconds(wordSpeed);
        //}

        //for(int i = 0; i < dialogueText.text.Length; i++)
        //{

        //}

        for (int i = 0; i < dialogue[index]; i++)
        {
            dialogueText.text += dialogue[i];
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(TypingText());
        }
        else
        {
            textRemoval();
        }
    }

    public void textRemoval()
    {
        dialogueText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
    }
    void Update()
    {
        StartCoroutine(TypingText());
    }
}
