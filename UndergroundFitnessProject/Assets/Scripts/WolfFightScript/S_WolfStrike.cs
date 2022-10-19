using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WolfStrike : MonoBehaviour
{
    public int numberOfAttacks;
    
    private int[] attacks;

    public Vector3[] attackLocations;
    private Vector3 startLocation;

    private bool attacking = true;

    private int attacksLeft;
    private int currentAttack = 0;
    private float timeTracker = 0;
    private bool direction = true;


    // Start is called before the first frame update
    void Start()
    {
        attacks = new int[numberOfAttacks];
        startLocation = gameObject.transform.position;

        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i] = Random.Range(0, 3);
        }
        attacksLeft = attacks.Length;

        SendAttackData();
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
            timeTracker += Time.deltaTime; //Tracks the time for the lerp


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

    private void SendAttackData()
    {

    }
}
