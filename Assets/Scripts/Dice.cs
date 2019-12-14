using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    // public because of protection level problems in other scripts.
    public DiceSide[] diceSides;
    public int diceValue;

    protected bool hasLanded;
    protected bool thrown;


    public Rigidbody rb;

    public static Vector3 startingPos;

    void Start()
    {
        //start at starting position
        startingPos = transform.position;
        rb = GetComponent<Rigidbody>();

    }
    // I made this to get the starting position of the dice and not the empty gameObject. so it calls this from a diffrent script to set the position back to the starting pos.
    public void StartPos()
    {
        transform.position = startingPos;
    }



    public void SideValueCheck()
    {

        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {

                diceValue = side.sideValue;

            }
        }

    }
}
