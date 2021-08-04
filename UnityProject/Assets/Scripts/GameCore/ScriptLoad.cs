using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScriptLoad
{

    public static void LoadText(string name)
    {
        UTF8Encoding utf8 = new UTF8Encoding();
        TextAsset txt = Resources.Load(name) as TextAsset;
        string[] str = txt.text.Split('\n');

        // parse character setting (line 2)
        string[] character_setting = str[0].Split(' ');
        Dictionary<string, string> character_dict = new Dictionary<string, string>();
        for (int i = 0; i < character_setting.Length / 2; i ++)
        {
            character_dict.Add(character_setting[i * 2], character_setting[i * 2 + 1]);
        }

        // amount of comment
        int comment_count = Regex.Matches(txt.text, "#").Count;
        // script is all text remove first line (character setting) length - 1
        string[] character_script = new string[str.Length - 1 - comment_count];
        // slice script lines from str array, start after character setting

        // difference between str pointer and character_script pointer
        // caused by the existence of comments
        int str_pointer_bias = 0;
        for (int i = 1; i < character_script.Length; i++)
        {
            
            if (str[i + str_pointer_bias].Substring(0, 1) == "#")
            {
                // skip comment
                str_pointer_bias += 1;
                i--;
                continue;
            }
            character_script[i - 1] = str[i + str_pointer_bias];
        }
        
        // parse script and fill codes with character names
        for (int i = 0; i < character_script.Length; i++)
        {
            try
            {
                string code = character_script[i].Split('=')[0];
                string value = character_script[i].Split('=')[1];
                character_script[i] = character_script[i].Replace(code, character_dict[code]);
            }
            catch
            {
                // do nothing if no matching replacement

            }
        }

        ScriptStorage.script_text = character_script;
    }

    public static void LoadScene(string _scene_name)
    {
        if (_scene_name != "None")
        {
            SceneManager.LoadScene(_scene_name, LoadSceneMode.Additive);
        }
    }
}
