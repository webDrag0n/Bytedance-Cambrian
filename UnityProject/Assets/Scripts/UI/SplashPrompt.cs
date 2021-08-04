using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SplashPrompt : MonoBehaviour
{
    private int lifeTime;
    private TMP_Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0;
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameStateStorage.prompt != "")
        {
            Debug.Log(GameStateStorage.prompt);
            text.text = GameStateStorage.prompt;
            GameStateStorage.prompt = "";
            lifeTime = 100;
            text.color = Color.white;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 255 * lifeTime / 100);

        if (lifeTime > 0)
        {
            lifeTime--;
        }
        else
        {
            lifeTime = 0;
            text.text = "";
            GameStateStorage.prompt = "";
        }
    }
}
