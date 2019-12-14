using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    // current route position check
    public Route currentRoute;

    int routePosition;

    public int steps;

    bool isMoving;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isMoving)
        {
            steps = DiceManager.endValue;
            Debug.Log(steps + " steps");

            if (routePosition + steps < currentRoute.tileNodeList.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
                Debug.Log("Rolled Number is invallid");
            }
        }
    }


    //IEnumerator is for not running it a second time if not needid
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            // I did routePosition + 2 because it counts the tile where the stone is standing on aswell. it would make sense if + 1 would have worked but for some reason it didn't.
            Vector3 nextPos = currentRoute.tileNodeList[routePosition + 2].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;

        }

        isMoving = false;
        steps = 0;
    }
    //Moves the character/stone to the next tile.
    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 4f * Time.deltaTime));

    }
}
