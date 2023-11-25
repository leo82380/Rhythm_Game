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
}
