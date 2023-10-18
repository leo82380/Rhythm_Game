using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
    IEnumerator coroutine;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(map.ToString());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        coroutine = VolumeDownRoutine();
        StopCoroutine(coroutine);
        audioSource.volume = 1f;
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
        while (audioSource.volume > 0)
        {
            audioSource.volume -= 0.01f;
            if (audioSource.volume <= 0)
                audioSource.Stop();
            yield return null;
        }
    }
}
