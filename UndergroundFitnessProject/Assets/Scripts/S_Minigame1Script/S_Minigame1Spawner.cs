using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Minigame1Spawner : MonoBehaviour
{
    public float spawnRate = 1, gameLength = 30;
    public GameObject spawnedEnemy; //Select the enemy you want to spawn. Must have the S_Minigame1Enemy script. 
    public int numberOfEnemies = 20;

    public GameObject ui;

    [Header("Will load a scene on end")]
    public Object scene;


    [Header("If set to true, the enemies will spawn from up to down or from down to up. If set to false, the enemies will move accross the screen from left to right or right to left.")]
    public bool verticalSpawn;


    [Header("Determines how fast the enemies move.")]
    public float enemySpeed = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnEnemies()
    {
        Time.timeScale = 1;
        spawnRate = 1 / spawnRate; //Makes it so the larger the number, the faster it spawns. 
        for(int i = 0; i < numberOfEnemies; i++)
        {
            StartCoroutine(SpawnEnemy(spawnRate * i, spawnedEnemy ));//Spawns the enemies 
        }
        ui.SetActive(false);
        //NextStage();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameLength <= 0)
        {
            NextStage();
        }
        else
        {
            gameLength -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval); 

        GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);
        newEnemy.GetComponent<S_Minigame1Enemy>().SetUp(verticalSpawn, enemySpeed); //A function I made to pass on some variables into the newly spawned enemies.
    }

    private void NextStage()
    {

        try
        {
            SceneManager.LoadScene(scene.name);
        }
        catch
        {
            Debug.Log("Error! Could not load level!");
        }
        
    }

}
