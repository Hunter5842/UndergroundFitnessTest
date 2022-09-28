using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ShowText : MonoBehaviour
{
    public GameObject textObject;
    public GameObject[] objectsToHide;
    public GameObject buttonText;

    public string buttonName = "Instructions";

    private bool on = false;
    private Text text;

    public void Start()
    {

        textObject.SetActive(false);
        text = buttonText.GetComponent<Text>();
    }

    public void ShowText()
    {
        if (!on)
        {
            Activate();
        }
        else
        {
            Back();
        }
    }

    private void Activate()
    {
        textObject.SetActive(true);

        for (int i = 0; i < objectsToHide.Length; i++)
        {
               objectsToHide[i].SetActive(false);
        }
        on = true;
        text.text = "back";
    }

    private void Back()
    {
        textObject.SetActive(false);

        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(true);
        }
        on = false;
        text.text = buttonName;
    }
}
