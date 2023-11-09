using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public enum Map
{
    ADanceOfFireAndIce,
    ButterflyPlanet,
    ThirdSun,
    DivineIntervention
}
public class MapChoice : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Map map;
    public AudioSource audioSource;
    public AudioClip audioClip;
    private IEnumerator coroutine;
    [SerializeField] private Image image;
    [SerializeField] private AudioSource clickAudioSource;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        clickAudioSource.Play();
        if (map != Map.ADanceOfFireAndIce)
        {
            image.transform.DOMoveY(0, 1f);
            return;
        }
        SceneManager.LoadScene(map.ToString());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        coroutine = VolumeDownRoutine();
        StopCoroutine(coroutine);
        audioSource.volume = 0.5f;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        coroutine = VolumeDownRoutine();
        StartCoroutine(coroutine);
    }

    IEnumerator VolumeDownRoutine()
    {
        if(audioSource == null) yield break;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= 0.01f;
            if (audioSource.volume <= 0)
                audioSource.Stop();
            yield return null;
        }
    }

    public void Back()
    {
        clickAudioSource.Play();
        image.transform.DOMoveY(-100, 1f);
    }
}
