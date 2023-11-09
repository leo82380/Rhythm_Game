using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player2 : MonoBehaviour
{
    public Action OnPlayerClear;
    Camera mainCamera;
    [SerializeField] private AudioSource audioSource;
    public AudioSource AudioSource => audioSource;
    
    private float minPos = -4.5f;
    private float maxPos = 4.5f;
    
    private void Awake()
    {
        mainCamera = Camera.main;
        audioSource = FindObjectOfType<AudioSource>();
    }
    
    void Update()
    {
        // Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        // transform.position = new Vector3(-7, Mathf.Clamp(mousePos.y, minPos, maxPos), transform.position.z);
        Clear();
    }
    private void Clear()
    {
        if(audioSource.time >= audioSource.clip.length)
        {
            OnPlayerClear?.Invoke();
        }
    }
    
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Note"))
    //     {
    //         collision.GetComponent<Note>().MoveEnd();
    //         UIManager.Instance.UpdateJudgeText(JudgeType.Perfect);
    //     }
    // }
}
