using System.Collections;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource _activeMusicSource, _calmMusicSource;

    private AudioSource _activeSource, _disabledSource;

    private void Start()
    {
        _activeSource = _calmMusicSource;
        _disabledSource = _activeMusicSource;
    }

    public void SwitchMusic()
    {
        StartCoroutine(SwitchVolume());
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
}
