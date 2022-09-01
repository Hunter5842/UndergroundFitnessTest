using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Minigame1Enemy : MonoBehaviour
{
    private float movementSpeed = 3f;
    //Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //A simple script that moves enemies to the right byt the movement speed multiplied by Delta Time. 
        transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
    }
}
