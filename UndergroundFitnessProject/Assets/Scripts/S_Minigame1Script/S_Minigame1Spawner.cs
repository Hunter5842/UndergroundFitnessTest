using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Minigame1Spawner : MonoBehaviour
{
    public float spawnRate = 1;
    public GameObject spawnedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnRate, spawnedEnemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);
        StartCoroutine(spawnEnemy(spawnRate, spawnedEnemy));
    }
}
