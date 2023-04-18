using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _globalMixer;
    [SerializeField] private Slider _musicSlider, _soundSlider;

    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        _soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1);
    }

    public void ChangeSoundVolume(float volume)
    {
        _globalMixer.audioMixer.SetFloat("SoundVolume", Mathf.Lerp(-40, 0, volume));
        PlayerPrefs.SetFloat("SoundVolume", volume);
        if(volume == 0)
        {
            _globalMixer.audioMixer.SetFloat("SoundVolume", -80);
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        _globalMixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-40, 0, volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
        if (volume == 0)
        {
            _globalMixer.audioMixer.SetFloat("MusicVolume", -80);
        }
    }
}
