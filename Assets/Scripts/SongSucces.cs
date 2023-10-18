using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SongSucces : MonoBehaviour
{
    private Player player;
    private Fader fader;
    private Note[] notes;
    
    
    private float playerHP = 100f;
    public float PlayerHP
    {
        get => playerHP;
        set
        {
            playerHP = value;
            if (playerHP <= 0f)
            {
                playerHP = 0f;
                Debug.Log("Player Die");
            }
        }
    }

    private void Awake()
    {
        try
        {
            player = FindObjectOfType<Player>();
            fader = FindObjectOfType<Fader>();
            notes = FindObjectsOfType<Note>();
        }
        catch
        {
            player = FindObjectOfType<Player>();
            fader = FindObjectOfType<Fader>();
            notes = FindObjectsOfType<Note>();
        }
    }

    private void Start()
    {
        player.OnPlayerDie += Die;
        player.OnPlayerClear += Clear;
    }

    private void OnDestroy()
    {
        player.OnPlayerDie -= Die;
        player.OnPlayerClear -= Clear;
    }

    private void Die()
    {
        StartCoroutine(PlayerDieRoutine());
    }
    IEnumerator PlayerDieRoutine()
    {
        fader.Fade();
        yield return new WaitUntil(() => fader.FadeImage.color.a >= 1f);
        SceneManager.LoadScene("GameOver");
    }

    private void Clear()
    {
        StartCoroutine(ClearRoutine());
    }
    IEnumerator ClearRoutine()
    {
        fader.Fade();
        player.AudioSource.Stop();
        yield return new WaitForSeconds(0.01f);
        player.gameObject.SetActive(false);
        foreach (var item in notes)
        {
            item.MoveEnd();
        }
        yield return new WaitUntil(() => fader.FadeImage.color.a >= 1f);
        SceneManager.LoadScene("Clear");
    }
}
