using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Minigame1Controller : MonoBehaviour
{
    public float movementCooldown = 0.2f;
    public float movementScale = 1;
    private float storedMovementCooldown;

    public Text text;
    

    //private BoxCollider2D collider;

    // Start is called before the first frame update
    void Awake()
    {
        storedMovementCooldown = movementCooldown;
    }

    private void Start()
    {
        //collider = GetComponent<BoxCollider2D>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (movementCooldown <= 0)
        {
            checkMovement();
        }
        else
        {
            movementCooldown -= Time.deltaTime;
        }
    }

    void checkMovement()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.position += new Vector3(movementScale, 0, 0);
            movementCooldown = storedMovementCooldown;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.position -= new Vector3(movementScale, 0, 0);
            movementCooldown = storedMovementCooldown;
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            transform.position += new Vector3(0, movementScale, 0);
            movementCooldown = storedMovementCooldown;
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            transform.position -= new Vector3(0, movementScale, 0);
            movementCooldown = storedMovementCooldown;
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
        }
    }
}
