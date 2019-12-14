using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiceManager : MonoBehaviour
{
    protected bool hasLanded;
    protected bool thrown;

    public GameObject[] dice;
    public Rigidbody[] rbs;
    public Dice Die;
    public Dice Die2;
    // Static isn't the best way but this was an simple fix for now.
    public static int endValue;
    
    




    void Start()
    {
        //dont want the dice to fall when the game starts
        DisableGravity();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RollAgain();
        }

        if (Die.rb.IsSleeping() && Die2.rb.IsSleeping() && !hasLanded && thrown)
        {

            hasLanded = true;
            DisableGravity();
            Debug.Log(hasLanded + "landed");
            // iknow that this is not the way how we should do it but for now ill just use this because at the time this takes to mutch time for me to do in a diffrent way. I wanted to make this so you can just add more dice if needed but that takes me a bit to long to figure out.
            Die.SideValueCheck();
           
            Die2.SideValueCheck();

            endValue = Die.diceValue + Die2.diceValue; 

        }
        
        
    }


   

    protected void RollDice()
    {
        if (!thrown && !hasLanded)
        {
            thrown = true;
            EnableGravity();
            AddTorque();
        }

        else if (thrown && hasLanded)
        {
            Reset();
        }

    }

    public void Reset()
    {
        Die2.StartPos();
        Die.StartPos();
        thrown = false;
        hasLanded = false;
        DisableGravity();

    }

    protected void RollAgain()
    {
        Reset();
        RollDice();
    }
    // I made functions for enabeling gravity and adding torque because otherwise it doesnt do this for all the rigidbodies in the array.
    protected void EnableGravity()
    {


        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].useGravity = true;
            Debug.Log("gravity on");
        }
    }

    protected void DisableGravity()
    {


        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].useGravity = false;
            Debug.Log("gravity off");
        }
    }

    protected void AddTorque()
    {
        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].AddTorque(Random.Range(0, 300), Random.Range(0, 300), Random.Range(0, 300));
        }
    }

}
