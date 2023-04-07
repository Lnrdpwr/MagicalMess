using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _damage;

    public int PiercingPower;
    public int ShootsCount;
    private bool _isReloaded = true;

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
        for(int i = ShootsCount; i > 0; i--)
        {
            Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.parent.rotation).GetComponent<Bullet>();
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);

            bullet.Damage = _damage;
            bullet.PiercingPower = PiercingPower;
        }
    }

    IEnumerator Reload()
    {
        _isReloaded = false;
        yield return new WaitForSeconds(_reloadTime);
        _isReloaded = true;
    }
}
