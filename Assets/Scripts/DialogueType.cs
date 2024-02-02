using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueType : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;
    private int sentenceIDX = -1;
    public StoryScene curScene;
    private State state = State.COMPLETED;
    public Animator animatorA;
    public Animator animatorB;
    public Dictionary<Speaker, SpriteController> sprites;
    public GameObject spritesPrefab;
    public GameObject spritesPrefab2;

    private bool canClick = true;
    private enum State
    {
        PLAYING, COMPLETED
    }

    private void Awake()
    {
        sprites = new Dictionary<Speaker, SpriteController>();
        animatorA = GetComponent<Animator>();
        animatorB = GetComponent<Animator>();
    }

    public void PlayScene(StoryScene scene)
    {
        curScene = scene;
        sentenceIDX = -1;
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        ++sentenceIDX; 
        StartCoroutine(TypeText(curScene.sentences[sentenceIDX].text));
        personNameText.text = curScene.sentences[sentenceIDX].speaker.speakerName;
        personNameText.color = curScene.sentences[sentenceIDX].speaker.textColor;
        ActSpeakers();
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIDX  == curScene.sentences.Count - 1;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIDX = 0;
        AudioManager.Instance.PlaySFX("Typing");
        AudioManager.Instance.mscSource.volume = 0.08f;
        if (canClick)
        {
            while (state != State.COMPLETED)
            {
                barText.text += text[wordIDX];
                yield return new WaitForSeconds(0.02f);
                if (Input.GetMouseButtonDown(0)  && state != State.COMPLETED)
                {
                    if (state == State.PLAYING)
                    {
                        StopAllCoroutines();
                        AudioManager.Instance.sfxSource.Pause();
                        barText.text = curScene.sentences[sentenceIDX].text;
                        state = State.COMPLETED;
                    }
                }
                if (++wordIDX == text.Length)
                {
                    state = State.COMPLETED;
                    break;
                }
            }
        }
        AudioManager.Instance.sfxSource.Pause();
    }


    public void DisableClick(){
        canClick = false;
    }

    public void EnableClick(){
        canClick = true;
    }

    private void ActSpeakers()
    {
        List<StoryScene.Sentence.Action> actions = curScene.sentences[sentenceIDX].actions;
        for(int i = 0; i < actions.Count; i++)
        {
            ActSpeaker(actions[i]);
        }
    }

    private void ActSpeaker(StoryScene.Sentence.Action action)
    {
        SpriteController controller = null;

        switch (action.actionType)
        {
            case StoryScene.Sentence.Action.Type.SHOW_CHAR1:
                if (!sprites.ContainsKey(action.speaker))
                {
                    controller = Instantiate(action.speaker.prefab.gameObject, spritesPrefab.transform)
                        .GetComponent<SpriteController>();
                    sprites.Add(action.speaker, controller);
                }
                else
                {
                    controller = sprites[action.speaker];
                }

                // Set up and show the Robin character
                // controller.Setup(action.speaker.sprites[action.spriteIDX]);
                // controller.ShowRobin();
                // controller.HideRona();
                  if(spritesPrefab == null){
                    Debug.Log("Sprites 1 miss");
                }else{
                    Debug.Log("sprite 2 miss");
                }
                spritesPrefab.SetActive(true);
                spritesPrefab2.SetActive(false);
                break;

            case StoryScene.Sentence.Action.Type.SHOW_CHAR2:
                if (!sprites.ContainsKey(action.speaker))
                {
                    controller = Instantiate(action.speaker.prefab.gameObject, spritesPrefab2.transform)
                        .GetComponent<SpriteController>();
                    sprites.Add(action.speaker, controller);
                }
                else
                {
                    controller = sprites[action.speaker];
                }

                // Set up and show the Rona character
                // controller.Setup(action.speaker.sprites[action.spriteIDX]);

                //hide robin good
                // controller.HideRobin();
                // controller.ShowRona();
                if(spritesPrefab == null){
                    Debug.Log("Sprites 1 miss");
                }else{
                    Debug.Log("sprite 2 miss");
                }
                spritesPrefab.SetActive(false);
                spritesPrefab2.SetActive(true);
                
                break;

            case StoryScene.Sentence.Action.Type.NONE:
                if (sprites.ContainsKey(action.speaker))
                {
                    controller = sprites[action.speaker];
                    Debug.Log("None");
                }
                break;
        }

    // if (controller != null)
    // {
    //     controller.SwitchSprite(action.speaker.sprites[action.spriteIDX]);
    // }
    }

}