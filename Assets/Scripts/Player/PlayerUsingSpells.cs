using UnityEngine;

public class PlayerUsingSpells : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _fireBallPrefab;
    [SerializeField] private GameObject _SmokeLeafPrefab;
    [SerializeField] private WitchScythe _witchScythe;

    private void UseElderScroll()
    {
        Instantiate(_fireBallPrefab, _firePoint.position, _firePoint.parent.rotation);
    }

    private void UseWitchScythe()
    {
        _witchScythe.gameObject.SetActive(true);
        _witchScythe.StartTimer();
    }

    private void UseSmoleLeaf()
    {
        Instantiate(_SmokeLeafPrefab, gameObject.transform.position, _SmokeLeafPrefab.transform.rotation);
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            UseSmoleLeaf();
        }
    }
}
