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
    
    
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;
    private AudioSource _hitSound;
    public int count = 0;
    
    private bool isHit = false;
    public bool IsHit => isHit;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
        _hitSound = GetComponent<AudioSource>();
        MoveNote(duration);
    }

    void MoveNote(float _duration)
    {
        transform.DOMoveX(-50f, _duration).OnComplete(Miss);
    }

    private void Miss()
    {
        if(isHit) return;
        _spriteRenderer.color = Color.clear;
        _collider2D.enabled = false;
        gameObject.name += "(miss)";
        DOTween.Kill(this);
        UIManager.Instance.UpdateJudgeText(JudgeType.Miss);
        StartCoroutine(DestroyNote());
    }

    public void MoveEnd()
    {
        if(isHit) return;
        _spriteRenderer.color = Color.clear;
        _collider2D.enabled = false;
        gameObject.name += "(Hit)";
        Instantiate(particle, transform.position, Quaternion.identity);
        DOTween.Kill(this);
        isHit = true;
        _hitSound.Play();
        StartCoroutine(DestroyNote());
    }
    
    IEnumerator DestroyNote()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
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
