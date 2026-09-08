using System;
using System.Collections.Generic;
using System.Linq;
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

    public int GetCurrentEquipedSkinWeapon(WeaponType weaponType){return playerData.CurrentEquipedWeaponSkin[(int)weaponType];}

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
        LevelManager.Instance.GetPlayer().GetVisual().ChangeVisualSkin(skinType, skinId);
        SaveData();
    }

     public bool IsThisSkinWeaponUnlock(WeaponType weaponType, int skinId)
    {
        int[] listSkinWeaponUnlock = playerData.ListWeaponDataSave[(int)weaponType].ListUnlockedSkin;
        for(int i = 0; i < listSkinWeaponUnlock.Length; i++)
        {
            if(listSkinWeaponUnlock[i] == skinId)
            {
                return true;
            }
        
        }
        return false;
    }

    public void AddNewSkinWeaponUnlock(WeaponType weaponType, int skinId)
    {
        if(IsThisSkinWeaponUnlock(weaponType, skinId))return;

        int[] newListSkinWeaponUnlock = new int[playerData.ListWeaponDataSave[(int)weaponType].ListUnlockedSkin.Length + 1];

        int[] oldListSkinWeaponUnlock = playerData.ListWeaponDataSave[(int)weaponType].ListUnlockedSkin;

        
        for(int i = 0; i < oldListSkinWeaponUnlock.Length; i++)
        {
            newListSkinWeaponUnlock[i] = oldListSkinWeaponUnlock[i];
        }
        newListSkinWeaponUnlock[newListSkinWeaponUnlock.Length - 1] = skinId;
        playerData.ListWeaponDataSave[(int)weaponType].ListUnlockedSkin = newListSkinWeaponUnlock;
        UIManager.Instance.GetUI<CanvasWeapon>().ReloadAllSkinSlot();
        SaveData();
    }

    public bool IsThisSkinWeaponChoosed(WeaponType weaponType, int skinId)
    {
        return playerData.CurrentEquipedWeaponSkin[(int)weaponType] == skinId;
    }

    public void UpdateCurrentSkinWeaponChoosed(WeaponType weaponType, int skinId)
    {
        playerData.CurrentEquipedWeaponSkin[(int)weaponType] = skinId;
        UIManager.Instance.GetUI<CanvasWeapon>().ReloadAllSkinSlot();
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
        playerData.ListWeaponDataSave = new WeaponDataSave[DataManager.Instance.GetTotalNumberWeapon()];
        playerData.CurrentEquipedWeaponSkin = new int[DataManager.Instance.GetTotalNumberWeapon()];
        for (int i = 0; i < GameConfig.TOTAL_SKINTYPE; i++)
        {
            playerData.ListUnlockedSkinDataSave[i] = CreateNewUnlockedSkinData(i);
            playerData.CurrentEquipedSkin[i] = 0;
        }

        for(int i= 0; i < DataManager.Instance.GetTotalNumberWeapon(); i++)
        {
            playerData.ListWeaponDataSave[i]  = CreateNewWeaponDataSave(i);
            playerData.CurrentEquipedWeaponSkin[i] = 0;
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

    public WeaponDataSave CreateNewWeaponDataSave(int weaponType)
    {
        WeaponDataSave weaponData;

        weaponData.WeaponType = weaponType;
        weaponData.ListUnlockedSkin = new int[1] {0};

        return weaponData;
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
