using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStateStorage
{
    // +1 each block
    public static int year;
    public static string chapter;
    public static int lineNumber;
    public static string playerName;
    public static bool isPaused;
    // init cam pos
    public static Vector3 camera_target_pos = new Vector3(-19, 25, -14);
    public static string current_line;
    public static Dictionary<string, int> user_defined_vars = new Dictionary<string, int>();

    // company / people
    public static Dictionary<string, int> reputations = new Dictionary<string, int>();
    public static float playerShipDurability = 100;
    public static float playerMineralStorage = 0;

    public static string prompt = "";

}
