using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Slider _musicSlider, _sfxSlider;

    public void Start(){
        if(!PlayerPrefs.HasKey("musicVol")){
            PlayerPrefs.SetFloat("musicVol", 1);
            BGMLoad();
        }else{
            BGMLoad();
        }

        if(!PlayerPrefs.HasKey("sfxVol")){
            PlayerPrefs.SetFloat("sfxVol",1);
            SFXLoad();
        }else{
            SFXLoad();
        }
    }
  
    public void ChangeBGMVolume(){
        AudioListener.volume =_musicSlider.value;
        BGMSave();
    }

    public void ChangeSFXVolume(){
        AudioListener.volume =_sfxSlider.value;
        SFXSave();
    }
    
    private void BGMLoad(){
        _musicSlider.value = PlayerPrefs.GetFloat("musicVol");
    }

    private void BGMSave(){
        PlayerPrefs.SetFloat("musicVol", _musicSlider.value);
    }

    private void SFXLoad(){
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
    }

    private void SFXSave(){
        PlayerPrefs.SetFloat("sfxVol", _sfxSlider.value);
    }
}
