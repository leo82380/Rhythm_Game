using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainButton : MonoBehaviour
{
    [SerializeField] [Tooltip("선택한 캐릭터")] private List<GameObject> characters;
    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject songPanel;
    [SerializeField] private Ease ease;

    private void Awake()
    {
        howToPlayPanel.transform.position = new Vector3(0f, -100f, 0f);
        GameObject character = Instantiate(characters[PlayerPrefs.GetInt("Character")], transform.position, Quaternion.identity);
        character.transform.localScale = new Vector3(5f, 5f, 5f);
    }
    public void StartGame()
    {
        songPanel.transform.DOMoveX(0f, 0.5f).SetEase(ease);
    }
    public void HowToPlay()
    {
        howToPlayPanel.transform.DOMoveY(0f, 0.5f).SetEase(ease);
    }

    public void BackMain(int i)
    {
        switch (i)
        {
            case 0:
                howToPlayPanel.transform.DOMoveY(-25f, 0.5f).SetEase(ease);
                break;
            case 1:
                songPanel.transform.DOMoveX(25f, 0.5f).SetEase(ease);
                break;
        }
        
    }
}
