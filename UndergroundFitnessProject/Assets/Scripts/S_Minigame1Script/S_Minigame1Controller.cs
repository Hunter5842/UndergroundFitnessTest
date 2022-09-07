using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Minigame1Controller : MonoBehaviour
{
    public float movementCooldown = 0.2f;
    public float movementScale = 1f;
    private float storedMovementCooldown;

    public Text text;
    private bool canMove = true;
    

    //private BoxCollider2D collider;

    // Start is called before the first frame update
    void Awake()
    {
        storedMovementCooldown = movementCooldown;
        movementScale = movementScale / 100;
    }

    private void Start()
    {
        //collider = GetComponent<BoxCollider2D>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            checkMovement();
        }
        
    }

    void checkMovement()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 && transform.position.x < 9)
        {
            transform.position += new Vector3(movementScale, 0, 0);
            //movementCooldown = storedMovementCooldown;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && transform.position.x > -9)
        {
            transform.position -= new Vector3(movementScale, 0, 0);
            //movementCooldown = storedMovementCooldown;
        }

        if (Input.GetAxisRaw("Vertical") == 1 && transform.position.y < 5)
        {
            transform.position += new Vector3(0, movementScale, 0);
            //movementCooldown = storedMovementCooldown;
        }
        else if (Input.GetAxisRaw("Vertical") == -1 && transform.position.y > -5)
        {
            transform.position -= new Vector3(0, movementScale, 0);
            //movementCooldown = storedMovementCooldown;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit by enemy!");
            Time.timeScale = 0;
            text.text = "You Lose!";
            text.color = Color.red;
            canMove = false;
        }
    }
}
