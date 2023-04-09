using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;

    private bool _isReloaded = true;

    public bool isTracked = false;
    public float ReloadTime;
    public float Damage;
    public float BulletForce;
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
        for(int i = ShootsCount; i > 0; i--)
        {
            Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.parent.rotation).GetComponent<Bullet>();
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_firePoint.up * BulletForce, ForceMode2D.Impulse);

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
