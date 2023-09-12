using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CharacterChoice : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Sprite[] characterSprites;
    [SerializeField] private GameObject choicePanel;

    private void Awake()
    {
        choicePanel.transform.position = new Vector3(0f, -50f, 0f);
    }

    public void Character(int num)
    {
        PlayerPrefs.SetInt("Character", num);
        
        characterImage.sprite = characterSprites[num];
        choicePanel.transform.DOMoveY(0f, 0.5f);
    }
    public void Yes()
    {
        SceneManager.LoadScene("Main");
    }
    public void No()
    {
        choicePanel.transform.DOMoveY(-11f, 0.5f);
    }
}
