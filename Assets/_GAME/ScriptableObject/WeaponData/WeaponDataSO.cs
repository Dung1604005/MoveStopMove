using System;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Scriptable Objects/Weapon/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField] private WeaponType weaponType;

    [SerializeField] private String nameWeapon;
    [SerializeField] private UnityEngine.Vector3 spawnPos;

    [SerializeField] private WeaponBase weaponPrefab;

    [SerializeField] private float rangeBuff;

    [SerializeField] private float cooldown;

    [SerializeField] private float atkBuff;

    [SerializeField] private float moveSpeedBullet;

    [SerializeField] private List<WeaponSkinData> listSkinData = new List<WeaponSkinData>();

    [SerializeField] private WeaponSkin modelSkinPrefab;
    public WeaponType WeaponType => weaponType;

    public String NameWeapon => nameWeapon;

    public float RangeBuff => rangeBuff;


    public float AtkBuff => atkBuff;

    public float Cooldown => cooldown;

    public float MoveSpeedBullet => moveSpeedBullet;

    public UnityEngine.Vector3 SpawnPos => spawnPos;

    public WeaponBase GetWeaponPrefab()
    {
        return weaponPrefab;
    }

    public WeaponSkinData GetWeaponSkinData(int skinId )
    {
        return listSkinData[skinId];
    }
    public WeaponSkinData GetRandomWeaponSkinData()
    {
        int skinId = UnityEngine.Random.Range(0, listSkinData.Count);
        return listSkinData[skinId];
    }

    public int GetTotalSkin()
    {
        return listSkinData.Count;
    }

    public WeaponSkin GetModelWeaponPrefab()
    {
        return modelSkinPrefab;
    }

    public String GetAllStatDescription()
    {
        String result = "";
        result = result + GetStatDescription(rangeBuff, "Range Atk");

        result = result + GetStatDescription(atkBuff, "Damage");

        return result;
    }

    public String GetStatDescription(float stat, String nameStat)
    {
        String result = "";
        if(stat > 0.01f)
        {
            result = nameStat + " + " + stat.ToString()+"\n";
        }

        return result;
    }
}


public enum WeaponType
{
    KNIFE = 0,
    SHIELD = 1,
    AXE_0 = 2,

    AXE_1 = 3,

    UZI= 4,

    HAMMER = 5,

    NONE = 99
}