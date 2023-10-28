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
                ESCPanel.SetActive(false);
                audioSource.Play();
                Time.timeScale = 1;
            }
            else
            {
                ESCPanel.SetActive(true);
                audioSource.Pause();
                Time.timeScale = 0;
            }
        }
    }
    
}
