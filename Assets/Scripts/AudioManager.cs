using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource mscSource, sfxSource;

    private void Awake () {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    private void Start() {
        PlayMusic("IntroMusic");
    }

    public void PlayFightBGM(){
        PlayMusic("BGM_FightScene");
        Debug.Log("Not get in");
    }
    
    public void PlayMusic(string name){
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if( s == null){
            Debug.Log("Music Sound Not Found");
        }else{
            mscSource.clip = s.clip;
            mscSource.Play();
        }
    }

     public void PlaySFX(string name){
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if( s == null){
            Debug.Log("Sound FX Not Found");
        }else{
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
