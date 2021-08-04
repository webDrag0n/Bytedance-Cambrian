using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceEncounterCore : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        SpaceEncounterData.playerHealth = 100;
        SpaceEncounterData.enemyHealth = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        // check enemy health first to increase player experience (maybe?
        if (SpaceEncounterData.enemyHealth <= 0)
        {
            win();
        }


        
        if (SpaceEncounterData.playerHealth <= 0)
        {
            lost();
        }
        
    }

    private void FixedUpdate()
    {
        // enemy constantly lose health
        //SpaceEncounterData.enemyHealth -= 0.1f;
    }

    public void lost()
    {
        GameStateStorage.playerShipDurability -= 10;
        SceneManager.UnloadSceneAsync("114514");
    }

    public void win()
    {
        GameStateStorage.playerMineralStorage += 10;
        SceneManager.UnloadSceneAsync("114514");
    }
}
