using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _reloadTime;

    private float _timer;
    public int ShootsCount;

    public void Start()
    {
        _timer = _reloadTime;
    }

    public void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0 && Input.GetButtonDown("Fire1"))
        {
            Shoot(ShootsCount);
            _timer = _reloadTime;
        }
    }

    private void Shoot(int count)
    {
        int i = ShootsCount;

        while (i > 0)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.parent.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce( _firePoint.up * _bulletForce, ForceMode2D.Impulse); ;

            i--;
        }
    }
}
