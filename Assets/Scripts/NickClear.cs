using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EasyJson;

public class NickClear : Singleton<NickClear>
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text nickNameText;

    protected override void Awake()
    {
        base.Awake();
    }

    public PlayerData PlayerData { get => playerData; set => playerData = value; }
    public void NickNameSave()
    {
        if (inputField.text.Length > 0)
        {
            playerData.nickName = inputField.text;
            EasyToJson.ToJson(playerData, "playerData", true);
        }
        else
        {
            return;
        }
    }
    
    public void NickNameRead()
    {
        playerData = EasyToJson.FromJson<PlayerData>("playerData");
        nickNameText = GameObject.FindGameObjectWithTag("NickText").GetComponent<TMP_Text>();
        nickNameText.text = playerData.nickName;
    }

    public void ClearSave(int perfect, int miss)
    {
        playerData.perfect = perfect;
        playerData.miss = miss;
        EasyToJson.ToJson(playerData, "playerData", true);
    }
}

[System.Serializable]
public class PlayerData
{
    public string nickName;
    public int perfect;
    public int miss;
}
