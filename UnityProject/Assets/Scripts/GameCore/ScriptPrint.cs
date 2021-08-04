using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptPrint : MonoBehaviour
{
    public TMP_Text tm_name;
    public TMP_Text tm_line;

    public GameObject option1;
    private TMP_Text option1_text;
    
    public GameObject option2;
    private TMP_Text option2_text;
    
    public GameObject option3;
    private TMP_Text option3_text;

    public Animator animator;
    
    private int line_index;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        line_index = 0;
        option1_text = option1.GetComponentInChildren<TMP_Text>();
        option2_text = option2.GetComponentInChildren<TMP_Text>();
        option3_text = option3.GetComponentInChildren<TMP_Text>();
        
    }

    public void NextLine()
    {
        if (GameStateStorage.isPaused)
        {
            return;
        }
        string curline = ScriptStorage.script_text[line_index];
        string main_text;
        string options_text;
        try
        {
            curline.Split('>');
        }
        catch
        {
            return;
        }
        if (curline.Split('>').Length > 1)
        {
            main_text = curline.Split('>')[0];
            options_text = curline.Split('>')[1];
            string[] options = options_text.Split(' ');
            option1_text.text = options[0].Split('|')[0];
            option1.GetComponent<OptionButton>().toScript = options[0].Split('|')[1];
            option2_text.text = options[1].Split('|')[0];
            option2.GetComponent<OptionButton>().toScript = options[1].Split('|')[1];
            option3_text.text = options[2].Split('|')[0];
            option3.GetComponent<OptionButton>().toScript = options[2].Split('|')[1];
        }
        else
        {
            main_text = curline;
            option1_text.text = "";
            option1.GetComponent<OptionButton>().toScript = "";
            option2_text.text = "";
            option2.GetComponent<OptionButton>().toScript = "";
            option3_text.text = "";
            option3.GetComponent<OptionButton>().toScript = "";
        }
        // name
        string n = main_text.Split('=')[0];
        // text
        string t = main_text.Split('=')[1];

        if (n == "LoadScene")
        {
            // parse scene setting (line 1)
            ScriptLoad.LoadScene("scene" + int.Parse(t).ToString());
        }else if (n == "UnloadScene")
        {
            SceneManager.UnloadSceneAsync("scene" + int.Parse(t).ToString());
        }
        else if (n == "CameraPos")
        {
            float x = float.Parse(t.Split(',')[0]);
            float z = float.Parse(t.Split(',')[1]);
            
            GameStateStorage.camera_target_pos = new Vector3(x, Camera.main.transform.position.y, z);
        }else if (n == "CameraShake")
        {
            // 1 = true, else = false
            bool isShake = (int.Parse(t) == 1);
            animator.SetBool("isShake", isShake);
        }else if (n == "@")
        {
            string variable_name = t.Split(' ')[0];
            string variable_value = t.Split(' ')[1];

            try
            {
                // try to find if this variable has already been defined
                GameStateStorage.user_defined_vars[variable_name] = int.Parse(variable_value);
            }
            catch
            {
                try
                {
                    // if not found, try create new variable
                    GameStateStorage.user_defined_vars.Add(variable_name, int.Parse(variable_value));
                }
                catch
                {
                    // invalid variable definition
                }
            }
        }else if (n == "Prompt")
        {
            GameStateStorage.prompt = t;
        }else if (n == "Minigame")
        {
            // load minigame scene
            SceneManager.LoadSceneAsync(int.Parse(t).ToString(), LoadSceneMode.Additive);
        }
        else
        {
            tm_name.text = n;
            tm_line.text = t;
            // record current line text
            GameStateStorage.current_line = t;
        }
        
        if (line_index < ScriptStorage.script_text.Length - 1)
        {
            line_index += 1;
        }
        
        
    }
}
