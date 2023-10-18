using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CharacterChoice : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Sprite[] characterSprites;
    [SerializeField] private GameObject choicePanel;
    [SerializeField] private Fader fader;

    private void Awake()
    {
        choicePanel.transform.position = new Vector3(0f, -50f, 0f);
    }

    public void Character(int num)
    {
        PlayerPrefs.SetInt("Character", num);
        
        characterImage.sprite = characterSprites[num];
        choicePanel.transform.DOMoveY(0f, 0.5f);
    }
    public void Yes()
    {
        StartCoroutine(YesCoroutine());
    }
    IEnumerator YesCoroutine()
    {
        fader.Fade();
        yield return new WaitUntil(() => fader.FadeImage.color.a == 1f);
        SceneManager.LoadScene("Main");
    }
    public void No()
    {
        choicePanel.transform.DOMoveY(-11f, 0.5f);
    }
}
