using System;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class PlayerDataController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;


    public int GetCurrentGold() {return playerData.GoldAmount;}

    public void UpdateGold(int _gold) {playerData.GoldAmount = _gold;}

    public string GetNamePlayer(){return playerData.NamePlayer;}

    public void UpdateNamePlayer(string _name){playerData.NamePlayer = _name;}

    public int GetCurrentEquipedSkin(SkinType skinType) {return playerData.CurrentEquipedSkin[(int)skinType];}

    public int[] GetArrUnlockedSkin(SkinType skinType)
    {
    
        return playerData.ListUnlockedSkinDataSave[(int)skinType].ListUnlockedSkin;
    }

    public bool IsThisSkinUnlocked(SkinType skinType, int skinId)
    {
        bool result = false;
        int[] listUnlockedSkin = playerData.ListUnlockedSkinDataSave[(int)skinType].ListUnlockedSkin;
        for(int i = 0; i < listUnlockedSkin.Length; i++)
        {
            if(listUnlockedSkin[i] == skinId)
            {
                result = true;
                break;
            }
        }

        return result;
    }


    public void SaveData()
    {
        String jsonText = JsonUtility.ToJson(playerData);

        PlayerPrefs.SetString(GameConfig.PLAYERDATA_KEY, jsonText);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        String jsonText = PlayerPrefs.GetString(GameConfig.PLAYERDATA_KEY);
        playerData = JsonUtility.FromJson<PlayerData>(jsonText);
    }



}
