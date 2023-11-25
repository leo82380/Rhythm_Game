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
        NickClear.Instance.NickNameSave();
    }

    public void NickRead()
    {
        NickClear.Instance.NickNameRead();
    }
}
