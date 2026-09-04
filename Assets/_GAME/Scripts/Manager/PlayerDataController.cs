using System;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class PlayerDataController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;


    public int GetCurrentGold() { return playerData.GoldAmount; }

    public bool CanAfford(int gold)
    {
        return gold <= playerData.GoldAmount;
    }

    public void ChangeGold(int _amount)
    {
        playerData.GoldAmount += _amount;
        UIManager.Instance.GetUI<CanvasMainMenu>().SetGoldText(playerData.GoldAmount);
        UIManager.Instance.GetUI<CanvasSkin>().SetGoldText(playerData.GoldAmount);

        SaveData();
    }

    public string GetNamePlayer() { return playerData.NamePlayer; }

    public void UpdateNamePlayer(string _name)
    {

        playerData.NamePlayer = _name;
        SaveData();
    }

    public int GetCurrentEquipedSkin(SkinType skinType) { return playerData.CurrentEquipedSkin[(int)skinType]; }

    public int[] GetArrUnlockedSkin(SkinType skinType)
    {

        return playerData.ListUnlockedSkinDataSave[(int)skinType].ListUnlockedSkin;
    }

    public bool IsThisSkinUnlocked(SkinType skinType, int skinId)
    {
        bool result = false;
        int[] listUnlockedSkin = playerData.ListUnlockedSkinDataSave[(int)skinType].ListUnlockedSkin;
        for (int i = 0; i < listUnlockedSkin.Length; i++)
        {
            if (listUnlockedSkin[i] == skinId)
            {
                result = true;
                break;
            }
        }

        return result;
    }

    public void UnlockSkin(SkinType skinType, int skinId)
    {
        int[] listUnlockedSkin = playerData.ListUnlockedSkinDataSave[(int)skinType].ListUnlockedSkin;

        int[] newListUnlockedSkin = new int[listUnlockedSkin.Length + 1];
        bool isThisSkinUnlocked = false;
        for (int i = 0; i < listUnlockedSkin.Length; i++)
        {
            newListUnlockedSkin[i] = listUnlockedSkin[i];
            if (listUnlockedSkin[i] == skinId)
            {
                isThisSkinUnlocked = true;
                break;
            }
        }

        newListUnlockedSkin[newListUnlockedSkin.Length - 1] = skinId;

        if (!isThisSkinUnlocked)
        {
            playerData.ListUnlockedSkinDataSave[(int)skinType].ListUnlockedSkin = newListUnlockedSkin;

            UIManager.Instance.GetUI<CanvasSkin>().ReloadAllSlots();
        }

        SaveData();
    }

    public bool IsThisSkinIdChoosed(SkinType skinType, int skinId)
    {
        if (playerData.CurrentEquipedSkin[(int)skinType] == skinId)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateCurrentSkinChoosed(SkinType skinType, int skinId)
    {
        playerData.CurrentEquipedSkin[(int)skinType] = skinId;
        UIManager.Instance.GetUI<CanvasSkin>().ReloadAllSlots();

        SaveData();
    }
    [ContextMenu("CREATE NEW DATA")]
    public void CreateNewData()
    {
        

        playerData.NamePlayer = "You";
        playerData.RankLevel = 1;
        playerData.GoldAmount = 100;
        //TODO: NEW DATA FOR WEAPON
        playerData.ListUnlockedSkinDataSave = new UnlockedSkinData[GameConfig.TOTAL_SKINTYPE];
        playerData.CurrentEquipedSkin = new int[GameConfig.TOTAL_SKINTYPE];
        for (int i = 0; i < GameConfig.TOTAL_SKINTYPE; i++)
        {
            playerData.ListUnlockedSkinDataSave[i] = CreateNewUnlockedSkinData(i);
            playerData.CurrentEquipedSkin[i] = 0;
        }
        SaveData();

    }
    public UnlockedSkinData CreateNewUnlockedSkinData(int skinType)
    {
        UnlockedSkinData unlockedSkinData;
        unlockedSkinData.SkinType = skinType;
        unlockedSkinData.ListUnlockedSkin = new int[1] { 0 };

        return unlockedSkinData;
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
