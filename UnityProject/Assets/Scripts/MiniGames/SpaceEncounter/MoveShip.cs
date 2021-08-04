using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{

    private float right_limit = 3;
    private float left_limit = -9;

    public Transform player;

    private void Start()
    {
        right_limit += SpaceEncounterData.playerTargetPosition.x;
        left_limit += SpaceEncounterData.playerTargetPosition.x;
    }

    public void moveRight()
    {
        if (SpaceEncounterData.playerTargetPosition.x < right_limit)
        {
            Debug.Log("right");
            SpaceEncounterData.playerTargetPosition += new Vector3(1f, 0, 0);
        }
    }

    public void moveLeft()
    {
        if (SpaceEncounterData.playerTargetPosition.x > left_limit)
        {
            SpaceEncounterData.playerTargetPosition += new Vector3(-1f, 0, 0);
        }
    }


}
