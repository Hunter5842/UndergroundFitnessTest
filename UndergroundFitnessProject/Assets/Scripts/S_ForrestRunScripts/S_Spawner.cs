using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Spawner : MonoBehaviour
{
    public GameObject spawnedObject;
    public bool repeatSpawn = true;
    public bool spawnAtStart = false;
    public float spawnInterval;
    public bool shutdownAfterTime = false;
    public float timeUntilShutdown = 30;

    public bool loadSceneOnEnd = true;
    [SerializeField]
    public Object nextScene;

    private float timeRemaining;
    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        if (shutdownAfterTime)
        {
            timeRemaining = timeUntilShutdown;
        }
        if (spawnAtStart)
        {
            countdown = 0;
            Spawn();
        }
        else
        {
            countdown = spawnInterval;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (repeatSpawn)
        {
            Spawn();
        }
        //Debug.Log(timeRemaining);
    }

    private void Spawn()
    {
        if(countdown <= 0)
        {
            Instantiate(spawnedObject, new Vector2(Random.RandomRange(-5, 5), Random.RandomRange(0, 3)), transform.rotation);
            countdown = spawnInterval;
        }
        else
        {
            countdown -= Time.deltaTime;
        }
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            Deactivate();
        }
    }

    public void Activate()
    {
        repeatSpawn = true;
        timeRemaining = timeUntilShutdown;
        //Debug.Log("Activated");
    }

    public void Deactivate()
    {
        repeatSpawn = false;
        timeRemaining = 0;

        SceneManager.LoadScene(nextScene.name);

        //Debug.Log("Deactivated");
    }
}
