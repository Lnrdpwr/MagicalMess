using UnityEngine;

public class Device : MonoBehaviour
{
    public void SelectMobile()
    {
        PlayerPrefs.SetString("InputType", "mobile");
    }

    public void SelectPC()
    {
        PlayerPrefs.SetString("InputType", "pc");
    }
}
