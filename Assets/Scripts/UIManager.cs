using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text progressText;
    [SerializeField] TMP_Text attemptsText;

    [SerializeField] AudioSource audioSource;

    float curTime = 0f;
    float progress = 0f;
    
    private void Update()
    {
        if(!audioSource.isPlaying) return;
        curTime += Time.deltaTime;
        float aLen = audioSource.clip.length;
        progress = Mathf.Round(curTime / aLen * 100); 

        progressText.text = "Progress: " + progress + "%";
    }

}
