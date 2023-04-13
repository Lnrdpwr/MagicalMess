using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSwitch : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
