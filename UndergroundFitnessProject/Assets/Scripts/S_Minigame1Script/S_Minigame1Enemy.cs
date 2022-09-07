using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Minigame1Enemy : MonoBehaviour
{
    private float movementSpeed = 3f;
    private bool direction = true;

    private float spawnVariation = 9;
    //Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(spawnVariation, -spawnVariation), transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //A simple script that moves enemies to the right byt the movement speed multiplied by Delta Time. 
        if (direction)
        {
            transform.position += new Vector3(0, movementSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }
    }

    public void SetUp(bool vertical, float speed)
    {
        direction = vertical;
        movementSpeed = speed;
    }
}
