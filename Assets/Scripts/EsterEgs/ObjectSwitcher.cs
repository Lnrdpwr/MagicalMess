using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    [SerializeField] private CrossBow _crossBow;
    [SerializeField] private SpriteRenderer _crossbowRenderer;
    [SerializeField] private Sprite _crossbowSprite;
    [SerializeField] private Sprite _cameraSpotSprite;

    private void SwitchToCamera()
    {
        _crossbowRenderer.sprite = _cameraSpotSprite;
        _crossBow.IsRotateble = false;
    }
    
    private void SwitchToCrossBow()
    {
        _crossbowRenderer.sprite = _crossbowSprite;
        _crossBow.IsRotateble = true;
    }
}
