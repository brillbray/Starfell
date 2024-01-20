using UnityEngine;

public class dialogPanelCutScenes1AnimationControler : MonoBehaviour
{
    public GameObject dp;
    private Animator animator;
    private DialogueType dialTyp;

    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (!dp.activeSelf)
            dp.SetActive(true);

        animator.SetTrigger("CutScenes1");
        enabled = false;
    }
}
