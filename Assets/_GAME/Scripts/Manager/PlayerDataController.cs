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

    public PantType GetCurrentPant(){return (PantType)playerData.CurrentPant ;}

    public HatType GetCurrentHat() {return (HatType)playerData.CurrentHat;}

    public int[] GetArrUnlockedPant()
    {
    
        return playerData.ListUnlockedPant;
    }

   public int[] GetArrUnlockedHat()
    {
    
        return playerData.ListUnlockedHat;
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
