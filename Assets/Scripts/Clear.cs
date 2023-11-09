using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clear : MonoBehaviour
{
    [SerializeField] private TMP_Text perfectText;
    [SerializeField] private TMP_Text missText;

    private void Awake()
    {
        perfectText.text = "Perfect " + PlayerPrefs.GetInt("Perfect").ToString();
        missText.text = "Miss     " + PlayerPrefs.GetInt("Miss").ToString();
    }
}
