using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;

    private bool _isReloaded = true;

    public bool isTracked = false;
    public float ReloadTime;
    public float Damage;
    public float Speed;
    public int PiercingPower; 
    public int ShootsCount;
    public Vector3 ArrowScale;

    public void Update()
    {
        if (_isReloaded && Input.GetButtonDown("Fire1"))
        {
            Shoot();
            StartCoroutine(Reload());
        }
    }

    private void Shoot()
    {
        int FixedShootsCount = ShootsCount - 1;
        float maxAngle = 80f;

        if (FixedShootsCount <= 0)
            FixedShootsCount = 1;

        for (float angle = -(maxAngle) / 2; angle <= maxAngle / 2; angle += maxAngle / FixedShootsCount)
        {
            Quaternion rotation = _firePoint.parent.rotation;

            if (ShootsCount > 1)
                rotation.z += angle * 0.001f;
            else
                rotation.z += 0;
            
            Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, rotation).GetComponent<Bullet>();

             bullet.Speed = Speed;
             bullet.Damage = Damage;
             bullet.PiercingPower = PiercingPower;
             bullet.transform.localScale = ArrowScale;
             bullet.isTrackActive = isTracked;    
        }   
    }

    IEnumerator Reload()
    {
        _isReloaded = false;
        yield return new WaitForSeconds(ReloadTime);
        _isReloaded = true;
    }
}
