using System.Collections;
using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private AnimationCurve _disappearCurve;
    [SerializeField] private AudioClip _spawnSound;

    private SpriteRenderer _acidRenderer;

    private void Start()
    {
        SoundManager.Instance.PlayClip(_spawnSound);
        _acidRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        float alpha = 1;
        for(float i = 0; i <= _lifeTime; i += Time.deltaTime)
        {
            alpha = _disappearCurve.Evaluate(i / _lifeTime);
            _acidRenderer.color = new Color(1, 1, 1, alpha);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
