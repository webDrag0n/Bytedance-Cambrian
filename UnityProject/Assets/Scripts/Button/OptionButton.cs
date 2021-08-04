using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{

    public string toScript;
    public ScriptPrint scriptPrint;

    public void Clicked()
    {
        if (GameStateStorage.isPaused)
        {
            return;
        }
        try
        {
            ScriptLoad.LoadText(toScript);
            // record chapter progress
            GameStateStorage.chapter = toScript;
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return;
        }
        scriptPrint.Initialize();
        scriptPrint.NextLine();
    }
}
