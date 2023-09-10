using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefabs;

    private void Awake()
    {
        Instantiate(playerPrefabs[PlayerPrefs.GetInt("Character")], transform.position, Quaternion.identity);
    }
}
