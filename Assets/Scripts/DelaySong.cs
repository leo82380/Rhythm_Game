using System.Collections;
using UnityEngine;

public class DelaySong : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float delay;
    private Fader fader;

    private bool isSongStarted = false;
    public bool IsSongStarted { get => isSongStarted; set => isSongStarted = value; }

    private void Awake()
    {
        try
        {
            audioSource = GetComponent<AudioSource>();
            fader = FindObjectOfType<Fader>();
        }
        catch 
        {
            audioSource = GetComponent<AudioSource>();
            fader = FindObjectOfType<Fader>();
        }
        
        StartCoroutine(Delay());
    }
    private IEnumerator Delay()
    {
        if(audioSource == null || fader == null)
        {
            yield break;
        }
        fader.FadeOut();
        yield return new WaitForSeconds(delay);
        audioSource.Play();
        IsSongStarted = true;
    }
}
