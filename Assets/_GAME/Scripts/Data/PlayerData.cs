using System;
using UnityEngine;

[Serializable]
public struct PlayerData
{
    public string NamePlayer;
    public int RankLevel;
    public int GoldAmount;
    public WeaponDataSave[] ListWeaponDataSave;

    public int[] ListUnlockedPant;

    public int[] ListUnlockedHat;

    public int CurrentPant;

    public int CurrentHat;


}
