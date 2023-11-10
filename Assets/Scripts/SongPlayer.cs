using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource song;
    
    private bool isPlaying = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPlaying)
        {
            if (other.CompareTag("Note"))
            {
                song.Play();
                isPlaying = true;
            }
        }
    }
}
