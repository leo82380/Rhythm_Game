using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpinLeo : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void Start()
    {
        float random = Random.Range(0f, 100f);
        if (random < 1f)
        {
            StartCoroutine(Spin());
        }
    }
    
    IEnumerator Spin()
    {
        spriteRenderer.enabled = true;
        while (true)
        {
            transform.Rotate(0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
