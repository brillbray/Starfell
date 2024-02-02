using UnityEngine;

public class PlayerStepOnTopGround : MonoBehaviour
{
    public SwitchScreen switchScreen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switchScreen.SwitchToNextScene();
        }
    }   

}
