using UnityEngine;

public class PlayerUsingSpells : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _fireBallPrefab;
    [SerializeField] private GameObject _witchScythePrefab;

    private void UseElderScroll()
    {
        EldenScroll eldenScroll = Instantiate(_fireBallPrefab, _firePoint.position, _firePoint.parent.rotation).GetComponent<EldenScroll>();
    }

    private void UseWitchScythe()
    {
        WitchScythe witchScythe =
            Instantiate(_witchScythePrefab, gameObject.transform.position, _witchScythePrefab.transform.rotation).GetComponent<WitchScythe>();

        witchScythe.Parent = gameObject.transform;
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
