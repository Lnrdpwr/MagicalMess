using UnityEngine;

public class PlayerUsingSpells : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _fireBallPrefab;

    private void UseElderScroll()
    {
        EldenScroll eldenScroll = Instantiate(_fireBallPrefab, _firePoint.position, _firePoint.parent.rotation).GetComponent<EldenScroll>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            UseElderScroll();
        }
    }
}
