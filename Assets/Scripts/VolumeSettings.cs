using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer AM;
    [SerializeField] private Slider mscSlider;

    private void Start()
    {
        SetMusicVolume();
    }

    public void SetMusicVolume()
    {
        float vol = mscSlider.value;
        AM.SetFloat("Music", Mathf.Log10(vol)*20);
    }
    public void LoadVolume()
    {

    }
}
