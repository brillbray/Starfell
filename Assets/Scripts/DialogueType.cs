using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueType : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    public int sentenceIDX = -1;
    public StoryScene curScene;
    private State state = State.COMPLETED;
    // public GameObject spkr;
    // public StoryScene speakerSprite;
    public SwitchScreen switchTheScreen;
    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        curScene = scene;
        sentenceIDX = -1;
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
         if (sentenceIDX < curScene.sentences.Count -1 )
         {
            ++sentenceIDX; 
            StartCoroutine(TypeText(curScene.sentences[sentenceIDX].text));
            personNameText.text = curScene.sentences[sentenceIDX].speaker.speakerName;
            personNameText.color = curScene.sentences[sentenceIDX].speaker.textColor;
         }  else{
             switchTheScreen.SwitchSceneName();       
         }


        
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIDX  == curScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIDX = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIDX];
            yield return new WaitForSeconds(0.02f);

            HandleLeftClick();  
            if (++wordIDX == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }

    void HandleLeftClick()
    {
        
        if (Input.GetMouseButtonDown(0) && state != State.COMPLETED)
        {
            if (state == State.PLAYING)
            {
                StopAllCoroutines();
                barText.text = curScene.sentences[sentenceIDX].text;
                state = State.COMPLETED;
            }

        }
    }
}