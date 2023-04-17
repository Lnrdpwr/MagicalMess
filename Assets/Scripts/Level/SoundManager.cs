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
}
