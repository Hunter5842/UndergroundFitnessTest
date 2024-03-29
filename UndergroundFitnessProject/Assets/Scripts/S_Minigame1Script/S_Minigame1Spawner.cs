using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_Minigame1Spawner : MonoBehaviour
{
    public float colorChangeRate = 50;
    public float spawnRate = 1, gameLength = 30;
    public GameObject spawnedEnemy; //Select the enemy you want to spawn. Must have the S_Minigame1Enemy script. 
    public int numberOfEnemies = 20;

    public SpriteRenderer background;

    public GameObject ui;

    public Text timer;

    public GameObject winUI;

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
        Color color = new Color(Time.deltaTime/colorChangeRate, Time.deltaTime/colorChangeRate, Time.deltaTime/colorChangeRate, 1);
        background.color += color;
        if(gameLength <= 0)
        {
            gameLength = 0;
            winUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameLength -= Time.deltaTime;
        }

        timer.text = "Time Left: " + gameLength.ToString();
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval); 

        GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);
        newEnemy.GetComponent<S_Minigame1Enemy>().SetUp(verticalSpawn, enemySpeed); //A function I made to pass on some variables into the newly spawned enemies.
    }

    public void NextStage()
    {

        try
        {
            SceneManager.LoadScene("Minigame3");
        }
        catch
        {
            
            Debug.Log("Error! Could not load level!");
        }
        
    }

}
