using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Nickname : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text text;
    public void Nick()
    {
        if (inputField.text.Length > 0)
        {
            File.WriteAllText(Application.dataPath + "/nickname.txt", inputField.text);
        }
        else
        {
            return;
        }
            
    }

    public void NickRead()
    {
        string nick = File.ReadAllText(Application.dataPath + "/nickname.txt");
        text.text = nick;
    }
}
