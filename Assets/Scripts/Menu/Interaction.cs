using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerShooting _playerShooting;

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.tag == "ShopButton")
            {
                _playerShooting.CanShoot = false;
            }
            else
            {
                _playerShooting.CanShoot = true;
            }
        }
    }
}
