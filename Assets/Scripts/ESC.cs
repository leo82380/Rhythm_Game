using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC : MonoBehaviour
{
    [SerializeField] GameObject ESCPanel;
    [SerializeField] AudioSource audioSource;
    DelaySong delaySong;

    private void Awake()
    {
        try
        {
            delaySong = FindObjectOfType<DelaySong>();
        }
        catch
        {
            delaySong = FindObjectOfType<DelaySong>();
        }
    }

    void Update()
    {
        if(delaySong.IsSongStarted == false) return;
        if(ESCPanel == null) return;
        if(audioSource == null) return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (ESCPanel.activeSelf)
            {
                Esc(false, 1f);
            }
            else
            {
                Esc(true, 0f);
            }
        }
    }

    private void Esc(bool active, float timeScale)
    {
        ESCPanel.SetActive(active);
        if (active)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
        Time.timeScale = timeScale;
    }
}
