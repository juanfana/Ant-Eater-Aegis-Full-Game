using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationScreens : MonoBehaviour
{
    public string SceneName;

    public void OnStartClick()
    {
        SceneManager.LoadScene(SceneName);
    }
}
