using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clear : MonoBehaviour
{
    [SerializeField] private TMP_Text perfectText;
    [SerializeField] private TMP_Text missText;
    [SerializeField] private TMP_Text clearText;

    private void Awake()
    {
        clearText.text = NickClear.Instance.PlayerData.miss == 0 ? "Stage Perfect!" : "Stage Clear!";

        perfectText.text = "Perfect " + NickClear.Instance.PlayerData.perfect;
        missText.text = "Miss     " + NickClear.Instance.PlayerData.miss;
    }
}
