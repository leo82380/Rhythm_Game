using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] TMP_Text progressText;
    [SerializeField] TMP_Text attemptsText;
    [SerializeField] TMP_Text perfectText;
    [SerializeField] TMP_Text missText;
    [SerializeField] AudioSource audioSource;
    
    public JudgeType JudgeType { get; set; }

    private int perfect = 0;
    private int miss = 0;
    private int attempts;

    float curTime = 0f;
    float progress = 0f;
    
    private void Start()
    {
        UpdateAttemptsText();
        if(PlayerPrefs.HasKey("Attempts" + SceneManager.GetActiveScene().name))
        {
            attempts = PlayerPrefs.GetInt("Attempts" + SceneManager.GetActiveScene().name);
        }
        else
        {
            attempts = 0;
        }
        print("PlayerPrefs" + PlayerPrefs.GetInt("Attempts" + SceneManager.GetActiveScene().name));
        print("attempts" + attempts);
        if (attemptsText == null)
        {
            return;
        }
        attemptsText.text = "Attempts: " + attempts;
    }
    private void Update()
    {
        if(!audioSource.isPlaying) return;
        curTime += Time.deltaTime;
        float aLen = audioSource.clip.length;
        progress = Mathf.Round(curTime / aLen * 100); 

        progressText.text = "Progress: " + progress + "%";
    }
    
    public void UpdateJudgeText(JudgeType judgeType)
    {
        switch(judgeType)
        {
            case JudgeType.Perfect:
                perfect++;
                perfectText.text = perfect.ToString();
                break;
            case JudgeType.Miss:
                miss++;
                missText.text = miss.ToString();
                break;
        }
    }
    
    public void UpdateAttemptsText()
    {
        if(PlayerPrefs.HasKey("Attempts" + SceneManager.GetActiveScene().name))
        {
            attempts = PlayerPrefs.GetInt("Attempts" + SceneManager.GetActiveScene().name);
        }
        else
        {
            attempts = 0;
        }
        attempts++;
        Debug.Log("Attempts1: " + attempts);
        PlayerPrefs.SetInt("Attempts" + SceneManager.GetActiveScene().name, attempts);
    }
    
}

public enum JudgeType
{
    Perfect,
    Miss
}