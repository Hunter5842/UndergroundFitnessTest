using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_WolfStrike : MonoBehaviour
{
    private float speed = 1.5f;
    public int numberOfAttacks;
    
    private int[] attacks;
    private int[] counterAttacks;

    private int currentCounterAttack = 0;

    public Vector3[] attackLocations;
    private Vector3 startLocation;

    private bool attacking = true;

    private int attacksLeft;
    private int currentAttack = 0;
    private float timeTracker = 0;
    private bool direction = true;

    public GameObject counterAttackButtons;

    public GameObject winScreen;
    
    public Text starsText;


    // Start is called before the first frame update
    void Start()
    {
        counterAttackButtons.SetActive(false);
        attacks = new int[numberOfAttacks];
        counterAttacks = new int[numberOfAttacks];

        startLocation = gameObject.transform.position;

        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i] = Random.Range(0, attackLocations.Length);
        }
        attacksLeft = attacks.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            Attack();
        }
        else if(0 < attacksLeft)
        {
            NextAttack();
        }
    }

    private void Attack()
    {
        if(direction)
        {
            timeTracker += Time.deltaTime * speed; //Tracks the time for the lerp
            if(timeTracker >= 1) // when the lerp reaches or surpasses 1, it changes direction.
            {
                timeTracker = 1;
                direction = false;
            }
        }
        else 
        {
            timeTracker -= Time.deltaTime;
            if(timeTracker <= 0) //when time tracker is less than 0, it proceeds to stop attacking, thus triggering the next attack
            {
                timeTracker = 0;
                attacking = false;
                if (0 == attacksLeft)
                {
                    counterAttackButtons.SetActive(true);
                }
            }
        }
        transform.position = Vector3.Lerp(startLocation, attackLocations[attacks[currentAttack]], timeTracker); // this updates the position relative to the location it belongs in. 
    }

    private void NextAttack() //triggers the next attack with incremental opperators and boolean resets. 
    {
        currentAttack++;
        attacksLeft--;
        direction = true;
        attacking = true;
    }

    public void attackSelected(int attackID)
    {
        counterAttacks[currentCounterAttack] = attackID;
        currentCounterAttack++;
        if(currentCounterAttack >= counterAttacks.Length)
        {
            counterAttackButtons.SetActive(false);
            winScreen.SetActive(true);
            if(compareAttacks())
            {
                starsText.text = "You got 3 Stars!";
            }
            else
            {
                starsText.text = "You got 2 Stars!";
            }
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Value Added: " + attackID + ". Current Counter Attack is " + currentCounterAttack + ". Counter Attacks Length is " + counterAttacks.Length);
        }
    }

    public bool compareAttacks()
    {
        for(int i = attacks.Length - 1; i >= 0; i--)
        {
            if(attacks[i] != counterAttacks[i])
            {
                return false;
            }
        }
        return true;
    }
}
