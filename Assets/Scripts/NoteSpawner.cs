using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    
    
    [SerializeField] Transform noteAppear = null;
    [SerializeField] GameObject notePrefab = null;

    public GameObject NotePrefab => notePrefab;

    public void Spawn()
    {
        GameObject note = Instantiate(notePrefab, noteAppear.position, Quaternion.identity);
        note.transform.SetParent(this.transform);
    }
}
