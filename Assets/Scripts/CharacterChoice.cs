using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class CharacterChoice : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Sprite[] characterSprites;
    [SerializeField] private GameObject choicePanel;
    [SerializeField] private GameObject nickNamePanel;
    [SerializeField] private Fader fader;
    [SerializeField] private Nickname nickname;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text label;

    private void Awake()
    {
        if (choicePanel != null)
        {
            choicePanel.transform.position = new Vector3(0f, -50f, 0f);
        }
    }

    public void Character(int num)
    {
        PlayerPrefs.SetInt("Character", num);
        
        if(characterImage != null && choicePanel != null)
        {
            characterImage.sprite = characterSprites[num];
            choicePanel.transform.DOMoveY(0f, 0.5f);
            audioSource.Play();
        }
    }

    public void YesCharacter()
    {
        if (characterImage != null)
        {
            nickNamePanel.transform.DOMoveY(0f, 0.5f);
            audioSource.Play();
        }
    }
    public void Yes()
    {
        StartCoroutine(YesCoroutine());
        audioSource.Play();
    }
    IEnumerator YesCoroutine()
    {
        if(inputField == null || label == null || fader == null)
        {
            yield break;
        }
        if(inputField.text.Length > 0)
        {
            label.text = "닉네임을 저장했습니다.";
            label.color = Color.green;
            nickname.Nick();
        }
        else
        {
            label.text = "닉네임을 1글자 이상으로 설정해주세요.";
            label.color = Color.red;
            yield return new WaitForSeconds(1.5f);
            label.text = "닉네임을 설정해주세요.";
            label.color = Color.white;
            yield break;
        }
        fader.Fade();
        yield return new WaitUntil(() => fader.FadeImage.color.a == 1f);
        SceneManager.LoadScene("Main");
    }
    public void No()
    {
        if(choicePanel != null && nickNamePanel != null)
        {
            choicePanel.transform.DOMoveY(-11f, 0.5f);
            nickNamePanel.transform.DOMoveY(-11f, 0.5f);
            audioSource.Play();
        }
    }
}
