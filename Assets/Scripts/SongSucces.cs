using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using Logger = Log.Logger;

public class SongSucces : MonoBehaviour
{
    private Player2 player;
    private Fader fader;
    private Note[] notes;
    
    
    private float playerHP = 100f;

    private void Awake()
    {
        try
        {
            player = FindObjectOfType<Player2>();
            fader = FindObjectOfType<Fader>();
            notes = FindObjectsOfType<Note>();
        }
        catch
        {
            player = FindObjectOfType<Player2>();
            fader = FindObjectOfType<Fader>();
            notes = FindObjectsOfType<Note>();
        }
    }

    private void Start()
    {
        player.OnPlayerClear += Clear;
    }

    private void OnDestroy()
    {
        player.OnPlayerClear -= Clear;
    }

    // private void Die()
    // {
    //     StartCoroutine(PlayerDieRoutine());
    // }
    // IEnumerator PlayerDieRoutine()
    // {
    //     fader.Fade();
    //     yield return new WaitUntil(() => fader.FadeImage.color.a >= 1f);
    //     SceneManager.LoadScene("GameOver");
    // }

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
        Logger.ColorLog("Clear", Color.green, false);
        SceneManager.LoadScene("Clear");
    }
}
