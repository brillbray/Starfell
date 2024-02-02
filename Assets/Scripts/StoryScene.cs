using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]
public class StoryScene : ScriptableObject
{
    public List<Sentence> sentences;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Speaker speaker;
        public List<Action> actions;
        public SpriteSwitcher prefab;
        [System.Serializable]
        public struct Action{
            public Speaker speaker;
            public int spriteIDX;
            public Type actionType;

            public enum Type{
                NONE,
                SHOW_CHAR1,
                SHOW_CHAR2,
            }
        }
    }
}