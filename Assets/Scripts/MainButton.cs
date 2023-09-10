using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    [SerializeField] [Tooltip("선택한 캐릭터")] private GameObject[] characters;
    [SerializeField] private GameObject howToPlayPanel;

    private void Awake()
    {
        howToPlayPanel.transform.position = new Vector3(0f, -100f, 0f);
        GameObject character = Instantiate(characters[PlayerPrefs.GetInt("Character")], transform.position, Quaternion.identity);
        character.transform.localScale = new Vector3(5f, 5f, 5f);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void HowToPlay()
    {
        howToPlayPanel.transform.DOMoveY(0f, 0.5f);
    }

    public void BackMain()
    {
        howToPlayPanel.transform.DOMoveY(-100f, 0.5f);
    }
}
