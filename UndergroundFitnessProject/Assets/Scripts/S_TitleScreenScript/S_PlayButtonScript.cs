using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class S_PlayButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string levelName; 

    public void PlayButton()
    {
        SceneManager.LoadScene(levelName);
    }
}
