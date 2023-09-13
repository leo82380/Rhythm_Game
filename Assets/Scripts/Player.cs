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

    public GameObject[] notes;
    public GameObject firstNote;
    public float shortDis;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerPos[0] = GameObject.Find("=====Position=====").transform.GetChild(1).gameObject;
        playerPos[1] = GameObject.Find("=====Position=====").transform.GetChild(0).gameObject;
        playerPos[2] = GameObject.Find("=====Position=====").transform.GetChild(2).gameObject;
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

        notes = GameObject.FindGameObjectsWithTag("Note");
        if (notes[0] != null)
        {
            shortDis = Vector3.Distance(gameObject.transform.position, notes[0].transform.position);
        }

        firstNote = notes[0]; // 첫번째를 먼저 
 
        foreach (GameObject found in notes)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);
 
            if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
            {
                firstNote = found;
                shortDis = Distance;
            }
        }
        if(Vector3.Distance(transform.position, firstNote.transform.position) < 1f && Input.anyKeyDown)
        {
            if (firstNote.GetComponent<Note>().noteType == NoteType.Normal)
            {
                firstNote.GetComponent<Note>().MoveEnd();
            }
            else if (firstNote.GetComponent<Note>().noteType == NoteType.Multiple)
            {
                ++firstNote.GetComponent<Note>().count;
                if (firstNote.GetComponent<Note>().count == 2)
                {
                    firstNote.GetComponent<Note>().MoveEnd();
                    firstNote.GetComponent<Note>().count = 0;
                }
            }
        }

    }
}
