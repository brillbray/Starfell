using System.Collections;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private SpriteSwitcher switcher;
    public Animator animatorA;
    public Animator animatorB;
    public GameObject chara1;
    public GameObject chara2;
    // private RectTransform rect;

    private void Awake()
    {
        switcher = GetComponent<SpriteSwitcher>();
        animatorA = GetComponent<Animator>();
        animatorB = GetComponent<Animator>();
        // rect = GetComponent<RectTransform>();
    }
    public void Setup(Sprite sprite)
    {
        switcher.SetImage(sprite);
    }


    public void ShowRobin()
    {
        animatorA.SetBool("Robin-Show",true);
        // animatorA.SetBool("Robin-Hide", false);
        // animatorB.SetBool("Rona-Show",false);
        // animatorB.SetBool("Rona-Hide",false);
        // chara1.SetActive(true);
        // chara2.SetActive(false);
        Debug.Log("Called Show Robin");

        // rect.localPosition = coords;
    }

    public void HideRobin()
    {
        animatorA.SetBool("Robin-Hide",true);
        // animatorA.SetBool("Robin-Show",false);
        // animatorB.SetBool("Rona-Show",false);
        // animatorB.SetBool("Rona-Hide",false);
        // chara1.SetActive(false);
        // chara2.SetActive(true);
        Debug.Log("Called Hide Robin");
    }

    public void ShowRona()
    { 
        // chara2.SetActive(true);
        chara1.SetActive(false);
        animatorB.SetBool("Rona-Show",true);
        // animatorB.SetBool("Rona-Hide",false);
        // animatorA.SetBool("Robin-Hide",false);
        // animatorA.SetBool("Robin-Show",false);
        Debug.Log("Called Show Rona");
    }

    public void HideRona()
    {
        // chara2.SetActive(false);
        // chara1.SetActive(false);
        animatorB.SetBool("Rona-Hide",true);
        // animatorB.SetBool("Rona-Show",false);
        // animatorA.SetBool("Robin-Hide",false);
        // animatorA.SetBool("Robin-Show",false);
        Debug.Log("Called Hide Rona");
    }

    // public void Move(Vector2 coords, float speed)
    // {
    //     StartCoroutine(MoveCoroutine(coords, speed));
    // }

    // private IEnumerator MoveCoroutine(Vector2 coords, float speed)
    // {
    //     while(rect.localPosition.x != coords.x || rect.localPosition.y != coords.y)
    //     {
    //         rect.localPosition = Vector2.MoveTowards(rect.localPosition, coords,
    //             Time.deltaTime * 1000f * speed);
    //         yield return new WaitForSeconds(0.01f);
    //     }
    // }

    public void SwitchSprite(Sprite sprite)
    {
        if (switcher.GetImage() != sprite)
        {
            switcher.SwitchImage(sprite);
        }
    }
}
