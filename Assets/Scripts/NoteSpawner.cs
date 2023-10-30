using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] notePrefab;
    
    public void SpawnNote()
    {
        int random = Random.Range(0, notePrefab.Length);
        Instantiate(notePrefab[random], transform.position, Quaternion.identity);
    }
}
