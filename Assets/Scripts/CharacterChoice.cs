using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CharacterChoice : MonoBehaviour
{
    [SerializeField] Image characterImage;
    [SerializeField] Sprite[] characterSprites;
    [SerializeField] GameObject choicePanel;

    private void Awake()
    {
        choicePanel.transform.position = new Vector3(0f, -100f, 0f);
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
        choicePanel.transform.DOMoveY(-100f, 0.5f);
    }
}
