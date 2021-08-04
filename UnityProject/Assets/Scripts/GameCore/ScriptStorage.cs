using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScriptStorage
{
    public static string a = "Test";
    public static Scene scene;

    private static string scene_name;
    public static string Scene_name
    {
        get { return scene_name; }
        set { scene_name = value; }
    }
    public static string next_script;
    public static string[] script_text;
    public static string[] options;

}
