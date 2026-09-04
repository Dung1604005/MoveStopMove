using System;
using UnityEngine;

[Serializable]
public struct PlayerData
{
    public string NamePlayer;
    public int RankLevel;
    public int GoldAmount;
    public WeaponDataSave[] ListWeaponDataSave;

    public UnlockedSkinData[] ListUnlockedSkinDataSave;

    public int[] CurrentEquipedSkin;


}


[Serializable]

public struct UnlockedSkinData
{
    public int SkinType;

    public int[] ListUnlockedSkin;
}