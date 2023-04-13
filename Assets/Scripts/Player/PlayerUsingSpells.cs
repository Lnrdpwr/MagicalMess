using UnityEngine;

public class PlayerUsingSpells : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _fireBallPrefab;
    [SerializeField] private WitchScythe _witchScythe;

    private void UseElderScroll()
    {
        EldenScroll eldenScroll = Instantiate(_fireBallPrefab, _firePoint.position, _firePoint.parent.rotation).GetComponent<EldenScroll>();
    }

    private void UseWitchScythe()
    {
        _witchScythe.gameObject.SetActive(true);
        _witchScythe.StartTimer();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            UseElderScroll();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseWitchScythe();
        }
    }
}
