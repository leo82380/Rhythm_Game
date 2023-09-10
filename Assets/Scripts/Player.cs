using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public KeyCode[] _upKeyCodes = { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P};
    [HideInInspector] public KeyCode[] _centerKeyCodes = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L };
    [HideInInspector] public KeyCode[] _downKeyCodes = { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M };

    [SerializeField] private GameObject[] playerPos;
    
    [HideInInspector] public Animator animator;

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
        foreach (var item in _upKeyCodes)
        {
            if(Input.GetKeyDown(item))
            {
                transform.position = playerPos[0].transform.position;
            }
        }
        foreach (var item in _centerKeyCodes)
        {
            if (Input.GetKeyDown(item))
            {
                transform.position = playerPos[1].transform.position;
            }
        }

        foreach (var item in _downKeyCodes)
        {
            if (Input.GetKeyDown(item))
            {
                transform.position = playerPos[2].transform.position;
            }
        }
    }
}
