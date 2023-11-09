using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] List<NoteSpawner> notes;

    private void Awake()
    {
        notes = new List<NoteSpawner>();
        notes.AddRange(GetComponentsInChildren<NoteSpawner>());
    }

    private void Start()
    {
        StartCoroutine(SpawnNotes());
    }
    IEnumerator SpawnNotes()
    {
        while(true)
        {
            yield return new WaitForSeconds(.6f);
            int random = UnityEngine.Random.Range(0, notes.Count);
            notes[random].SpawnNote();
        }
    }
}
