using System.Collections;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource _activeMusicSource, _calmMusicSource;

    private AudioSource _activeSource, _disabledSource;
    private bool _canSwitch = true;

    private void Start()
    {
        
        _activeSource = _calmMusicSource;
        _disabledSource = _activeMusicSource;
        StartCoroutine(StartMusicTransition());
    }

    public void SwitchMusic()
    {
        StartCoroutine(SwitchVolume());
    }

    public void StopMusic()
    {
        if (_canSwitch)
        {
            StartCoroutine(EndMusic());
            _canSwitch = false;
        }
        
    }

    public void SetVolume(float volume)
    {
        _activeSource.volume = volume;
        _disabledSource.volume = 0;
    }

    public void ResetMusic()
    {
        _canSwitch = true;
        _activeSource = _calmMusicSource;
        _disabledSource = _activeMusicSource;
        _activeSource.volume = 1;
        _disabledSource.volume = 0;
    }

    IEnumerator SwitchVolume()
    {
        for(float i = 0; i <= 3; i += Time.deltaTime)
        {
            _activeSource.volume = 1 - i/3;
            _disabledSource.volume = i/3;
            yield return new WaitForEndOfFrame();
        }
        _activeSource.volume = 0;
        _disabledSource.volume = 1;

        AudioSource temp = _activeSource;
        _activeSource = _disabledSource;
        _disabledSource = temp;
    }

    IEnumerator StartMusicTransition()
    {
        for(float i = 0; i <= 2; i += Time.deltaTime)
        {
            _activeSource.volume = i / 2;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator EndMusic()
    {
        for (float i = 2; i > 0; i -= Time.deltaTime)
        {
            _activeSource.volume = i / 2;
            yield return new WaitForEndOfFrame();
        }
    }
}
