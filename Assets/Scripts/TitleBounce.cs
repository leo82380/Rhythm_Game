using System;
using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TitleBounce : MonoBehaviour
{
    private TMP_Text title;
    
    [SerializeField] private float duration = 1f;
    [SerializeField] private Ease ease = Ease.InOutSine;

    private void Awake()
    {
        title = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        title.gameObject.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), duration).SetLoops(-1).SetEase(ease);
        StartCoroutine(Rotation());
    }

    private IEnumerator Rotation()
    {
        while (true)
        {
            title.gameObject.transform.DORotate(new Vector3(0, 0, 3), duration).SetEase(ease);
            yield return new WaitUntil(() => Vector3.Distance(title.gameObject.transform.localScale, new Vector3(1.1f, 1.1f, 1.1f)) < 0.025f);
            title.gameObject.transform.DORotate(new Vector3(0, 0, -3), duration).SetEase(ease);
            yield return new WaitUntil(() => Vector3.Distance(title.gameObject.transform.localScale, new Vector3(1.1f, 1.1f, 1.1f)) < 0.025f);
        }
    }
}
