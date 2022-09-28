using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WolfStrike : MonoBehaviour
{
    public int numberOfAttacks;
    private int[] attacks;

    public Vector3[] attackLocations;

    private bool attacking;

    private int attacksLeft;


    // Start is called before the first frame update
    void Start()
    {
        attacks = new int[numberOfAttacks];
        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i] = Random.Range(0, 4);

        }
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

    }

    private void NextAttack()
    {

    }
}
