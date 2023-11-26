using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Record : MonoBehaviour
{
    private TMP_Text recordText;

    private void Awake()
    {
        recordText = GetComponent<TMP_Text>();
    }
    void Start()
    {
        recordText.text = "Perfect - " + NickClear.Instance.PlayerData.perfect + "\nMiss - " + NickClear.Instance.PlayerData.miss;
    }
}
