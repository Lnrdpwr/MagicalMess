using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;

    private bool _isReloaded = true;

    public bool isTracked = false;//Метка монстра
    public float ReloadTime;//Перезарядка
    public float Damage;//Урон
    public float Speed;//Скорость снаряда
    public int PiercingPower;//Пронзание
    public int ShootsCount;//Кол-во выстрелов
    public Vector3 ArrowScale;//Размер стрелы
    public float MaxAngle = 0f;//Фиксированный разброс

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
        float maxAngle = 80f;

        for (float angle = -(maxAngle) / 2; angle < maxAngle / 2; angle += maxAngle / ShootsCount)
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
