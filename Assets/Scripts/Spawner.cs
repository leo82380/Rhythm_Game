using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefabs;

    private void Awake()
    {
        print(PlayerPrefs.GetInt("Character"));
        Instantiate(playerPrefabs[PlayerPrefs.GetInt("Character")], transform.position, Quaternion.identity);
        if (SceneManager.GetActiveScene().name == "Clear")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.localScale = new Vector3(4f, 4f, 4f);
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void Again()
    {
        SceneManager.LoadScene(0);
    }
}
