using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] List<NoteSpawner> notes;
    [SerializeField] AudioSource song;
    [SerializeField] float bpm = 0;
    double currentTime = 0d;
    private int randomIndex;

    private void Awake()
    {
        notes = new List<NoteSpawner>();
        notes.AddRange(GetComponentsInChildren<NoteSpawner>());
    }

    private void Start()
    {
        bpm = 150f * song.pitch;
        StartCoroutine(Random());
    }

    private void Update()
    {
        if (UIManager.Instance.Progress >= 82.3f) bpm = 37.5f * song.pitch;
        //Sink();
        if (UIManager.Instance.Progress >= 97f) return;
        
        currentTime += Time.deltaTime; 
        if (currentTime >= 60d / bpm) 
        { 
            notes[randomIndex].Spawn();
            currentTime -= 60d / bpm;
        }
    }

    IEnumerator Random()
    {
        while (UIManager.Instance.Progress < 100)
        {
            randomIndex = UnityEngine.Random.Range(0, notes.Count);
            if(randomIndex == 0) notes[randomIndex].NotePrefab.GetComponent<Note>().notePos = NotePos.Up;
            else if(randomIndex == 1) notes[randomIndex].NotePrefab.GetComponent<Note>().notePos = NotePos.Center;
            else if(randomIndex == 2) notes[randomIndex].NotePrefab.GetComponent<Note>().notePos = NotePos.Down;
            yield return new WaitForSeconds(1f);
        }
    }

    void Sink()
    {
        if (UIManager.Instance.Progress >= 15f) bpm = 75f * song.pitch;
        if (UIManager.Instance.Progress >= 16f) bpm = 150f * song.pitch;
        if (UIManager.Instance.Progress >= 23f) bpm = 75f * song.pitch;
        if (UIManager.Instance.Progress >= 24f) bpm = 150f * song.pitch;
        if (UIManager.Instance.Progress >= 31f) bpm = 75f * song.pitch;
        if (UIManager.Instance.Progress >= 32f) bpm = 150f * song.pitch;
        if (UIManager.Instance.Progress >= 39f) bpm = 75f * song.pitch;
        if (UIManager.Instance.Progress >= 40f) bpm = 150f * song.pitch;
        if (UIManager.Instance.Progress >= 48f) bpm = 75f * song.pitch;
        if (UIManager.Instance.Progress >= 49f) bpm = 150f * song.pitch;
        if (UIManager.Instance.Progress >= 55f) bpm = 75f * song.pitch;
        if (UIManager.Instance.Progress >= 59f) bpm = 150f * song.pitch;
        if (UIManager.Instance.Progress >= 63f) bpm = 75f * song.pitch;
        if (UIManager.Instance.Progress >= 68f) bpm = 150f * song.pitch;
        if (UIManager.Instance.Progress >= 71f) bpm = 75f * song.pitch;
        if (UIManager.Instance.Progress >= 75f) bpm = 150f * song.pitch;
        if (UIManager.Instance.Progress >= 77f) bpm = 300f * song.pitch;
        
        
    }
}
