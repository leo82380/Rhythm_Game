using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private KeyCode[] _upKeyCodes = { KeyCode.E, KeyCode.U };
    private KeyCode[] _centerKeyCodes = { KeyCode.D, KeyCode.J };
    private KeyCode[] _downKeyCodes = { KeyCode.C, KeyCode.M };

    [SerializeField] private GameObject[] playerPos;
    
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerPos[0] = GameObject.Find("UpPos");
        playerPos[1] = GameObject.Find("CenterPos");
        playerPos[2] = GameObject.Find("DownPos");
        transform.position = playerPos[1].transform.position;
        animator.SetBool("isRun", true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(_upKeyCodes[0]) || Input.GetKeyDown(_upKeyCodes[1]))
        {
            Debug.Log("Up");
            transform.position = playerPos[0].transform.position;
        }
        if (Input.GetKeyDown(_centerKeyCodes[0]) || Input.GetKeyDown(_centerKeyCodes[1]))
        {
            Debug.Log("Center");
            transform.position = playerPos[1].transform.position;
        }
        if (Input.GetKeyDown(_downKeyCodes[0]) || Input.GetKeyDown(_downKeyCodes[1]))
        {
            Debug.Log("Down");
            transform.position = playerPos[2].transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
