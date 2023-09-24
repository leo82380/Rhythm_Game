using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefabs;

    private void Start()
    {
        Instantiate(playerPrefabs[PlayerPrefs.GetInt("Character")], transform.position, Quaternion.identity);
    }
}
