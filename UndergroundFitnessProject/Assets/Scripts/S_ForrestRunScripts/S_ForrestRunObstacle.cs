using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct namedSprite
{
    public string name;
    public Sprite sprite;
}


public class S_ForrestRunObstacle : MonoBehaviour
{
    public namedSprite[] obstacles;
    public float timeOnScreen = 2;
    public float endScale = 3;
    public float scaleSpeed = 1;

    private Vector3 scale = new Vector3(0, 0, 1);
    private SpriteRenderer spriteRenderer;
    private float timeElapsed = 0;
    private float timeBeforeKill = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = obstacles[Random.Range(0, obstacles.Length - 1)].sprite;
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed * scaleSpeed <= endScale)
        {
            ScaleUp();
            //Debug.Log(timeElapsed);
        }
        else
        {
            DelayKill();
        }
    }

    private void ScaleUp()
    {
        timeElapsed += Time.deltaTime;
        transform.localScale = new Vector3(timeElapsed * scaleSpeed, timeElapsed * scaleSpeed, 1);
    }

    private void DelayKill()
    {
        transform.localScale = new Vector3(endScale, endScale, 1);


        timeBeforeKill += Time.deltaTime;
        if (timeBeforeKill >= timeOnScreen)
        {
            Destroy(gameObject);
        }
    }
}
