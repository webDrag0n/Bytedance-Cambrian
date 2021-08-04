using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPause : MonoBehaviour
{
    public GameObject pause_menu;
    
    public void Trigger()
    {
        pause_menu.SetActive(true);
        GameStateStorage.isPaused = true;
    }
}
