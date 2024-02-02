
using UnityEngine;
using UnityEngine.UI;
public class SpriteSwitcher : MonoBehaviour
{
    public bool isSwitched = false;

    public Image img1;
    public Image img2;
    public Animator animator;


    public void SwitchImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            img2.sprite = sprite;
            animator.SetBool("Robin-Show",true);
        }
        else
        {
            img1.sprite = sprite;
            animator.SetBool("Robin-Show",false);
        }
        isSwitched = !isSwitched;
    }

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            img1.sprite = sprite;
        }
        else
        {
            img2.sprite = sprite;
        }
    }

    public Sprite GetImage()
    {
        if (!isSwitched)
        {
            return img1.sprite;
        }
        else
        {
            return img2.sprite;
        }
    }
}
