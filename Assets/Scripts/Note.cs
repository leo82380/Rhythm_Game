using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public enum NoteType
{
    Normal,
    Multiple
}
public class Note : MonoBehaviour
{
    [SerializeField] private NoteType noteType;
    [SerializeField] private float duration;
    private void Awake()
    {
        MoveNote(duration);
    }
    void MoveNote(float duration)
    {
        transform.DOMoveX(-50f, duration).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
    }

    private void OnDestroy()
    {
        DOTween.Kill(this);
    }

    private void OnApplicationQuit()
    {
        DOTween.KillAll();
    }
}
