using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] Image profileImage;
    [SerializeField] Sprite[] profileImages;

    private void Start()
    {
        profileImage.sprite = profileImages[PlayerPrefs.GetInt("Character")];
    }
}
