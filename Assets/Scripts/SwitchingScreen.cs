using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingScreen : MonoBehaviour
{
    public SwitchScreen ss;

    private void Start() {
        AudioManager.Instance.PlayFightBGM();
    }
    void Update()
    {
        StartCoroutine(SwitchToIntro());
    }

    private IEnumerator SwitchToIntro(){
        yield return new WaitForSeconds(9f);
        ss.SwitchSceneName();
    }
}
