using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{

    public GameObject fire;
    public GameObject smoke;
    
    private void Start()
    {
        fire.SetActive(false);
        smoke.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (GameStateStorage.user_defined_vars["Launch"] == 1)
            {
                GetComponent<Animator>().SetBool("Launch", true);
                fire.SetActive(true);
                smoke.SetActive(true);
            }
        }
        catch
        {
            // do nothing
        }
        
    }
}
