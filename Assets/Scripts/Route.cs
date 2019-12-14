using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    //array of positions from the tiles
    Transform[] tiles;

    // this is public because it is called in Stone.cs
    public List<Transform> tileNodeList = new List<Transform>();

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        FillTiles();
        // for every tile in the list it has a position and draws a line between them.
        for (int i = 0; i < tileNodeList.Count; i++)
        {
            Vector3 currentpos = tileNodeList[i].position;
            if(i > 0)
            {
                Vector3 prevPos = tileNodeList[i - 1].position;
                Gizmos.DrawLine(prevPos, currentpos);
            }
        }
    }

    void FillTiles()
    {
        tileNodeList.Clear();

        // Gets the position so the player can get that position and walk there.
        tiles = GetComponentsInChildren<Transform>();

        // Adds Tile into the tile list.
        foreach(Transform tile in tiles)
        {
            if(tile != this.transform)
            {
                tileNodeList.Add(tile);
            }
        }
    }
}
