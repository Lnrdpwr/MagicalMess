using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _singleAudioSource;
    internal static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
        _singleAudioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        _singleAudioSource.PlayOneShot(clip);
    }

    public void SetVolume(float volume)
    {
        _singleAudioSource.volume = volume;
    }
}
