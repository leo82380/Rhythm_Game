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
    [SerializeField] public NoteType noteType;
    [SerializeField] private float duration;
    SpriteRenderer spriteRenderer;
    Collider2D collider2D;
    public int count = 0;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        MoveNote(duration);
    }
    void MoveNote(float duration)
    {
        transform.DOMoveX(-50f, duration).SetEase(Ease.Linear).OnComplete(MoveEnd);
    }

    public void MoveEnd()
    {
        spriteRenderer.color = Color.clear;
        collider2D.enabled = false;
        gameObject.name = gameObject.name + "(Hit)";
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
