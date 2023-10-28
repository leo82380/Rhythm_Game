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
    [SerializeField] GameObject particle;
    
    SpriteRenderer _spriteRenderer;
    Collider2D _collider2D;
    public int count = 0;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
        MoveNote(duration);
    }
    void MoveNote(float _duration)
    {
        transform.DOMoveX(-50f, _duration).SetEase(Ease.Linear).OnComplete(MoveEnd);
    }

    public void MoveEnd()
    {
        _spriteRenderer.color = Color.clear;
        _collider2D.enabled = false;
        gameObject.name += "(Hit)";
        Instantiate(particle, transform.position, Quaternion.identity);
        DOTween.Kill(this);
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
