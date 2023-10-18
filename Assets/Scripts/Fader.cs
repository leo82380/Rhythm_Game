using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    public Image FadeImage => fadeImage;
    public void Fade()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(0f, 0f, 0f, 0f);
        fadeImage.DOFade(1f, 1f);
        StartCoroutine(Off(1f));
    }
    public void FadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(0f, 0f, 0f, 1f);
        fadeImage.DOFade(0f, 1f);
        StartCoroutine(Off(0f));
    }
    IEnumerator Off(float alpha)
    {
        yield return new WaitUntil(() => fadeImage.color.a == alpha);
        fadeImage.gameObject.SetActive(false);
    }
}
