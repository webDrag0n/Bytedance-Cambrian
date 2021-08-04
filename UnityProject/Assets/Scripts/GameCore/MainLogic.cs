using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLogic : MonoBehaviour
{

    public GameObject s1;

    public GameObject s2;
    // private AssetBundle myLoadedAssetBundle;
    // private string[] scenePaths;
    // Start is called before the first frame update
    void Start()
    {
        ScriptLoad.LoadText("chapter0");
        
        GameStateStorage.reputations.Add("company", 20);
        GameStateStorage.reputations.Add("people", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
