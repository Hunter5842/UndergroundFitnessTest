using UnityEngine;
using UnityEngine.SceneManagement;

[SerializeField]
public enum LoadType
{
    Name,
    Scene
}

public class S_LoadScene : MonoBehaviour
{
    public string sceneName;
    public Scene scene;
    public LoadType loadType = LoadType.Name;

    public void loadScene()
    {
        if(loadType == LoadType.Name)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            SceneManager.LoadScene(scene.name);
        }
        
    }
}
