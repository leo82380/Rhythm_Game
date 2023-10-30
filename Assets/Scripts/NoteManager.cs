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
        int index = 0;
        index = Mathf.Clamp(index, 0, notes.Count - 1);
        while(true)
        {
            yield return new WaitForSeconds(1f);
            notes[index].SpawnNote();
            index++;
            if(index == notes.Count)
            {
                index = 0;
            }
        }
    }
}
