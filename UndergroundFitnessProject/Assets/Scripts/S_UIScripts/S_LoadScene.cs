using UnityEngine;
using UnityEngine.SceneManagement;

public class S_LoadScene : MonoBehaviour
{
    public string sceneName;

    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
