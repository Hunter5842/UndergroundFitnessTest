using UnityEngine;
using UnityEngine.UI;

public class S_PressPlayToStart : MonoBehaviour
{
    public Canvas canvas;
    public GameObject objectToRemove;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void startGame()
    {
        Time.timeScale = 1;

        if (objectToRemove != null)
        {
            Destroy(objectToRemove);
        }
    }
}
