using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Scriptable Objects/Weapon/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private UnityEngine.Vector3 spawnPos;

    [SerializeField] private WeaponBase weaponPrefab;

    [SerializeField] private float rangeBuff;

    [SerializeField] private float cooldown;

    [SerializeField] private float atkBuff;

    [SerializeField] private float moveSpeedBullet;

    [SerializeField] private List<WeaponSkinData> listSkinData = new List<WeaponSkinData>();

    [SerializeField] private WeaponSkin modelSkinPrefab;
    public WeaponType WeaponType => weaponType;

    public float RangeBuff => rangeBuff;


    public float AtkBuff => atkBuff;

    public float Cooldown => cooldown;

    public float MoveSpeedBullet => moveSpeedBullet;

    public UnityEngine.Vector3 SpawnPos => spawnPos;

    public WeaponBase GetWeaponPrefab()
    {
        return weaponPrefab;
    }

    public List<WeaponSkinData> GetWeaponSkinData()
    {
        return listSkinData;
    }

    public WeaponSkin GetModelWeaponPrefab()
    {
        return modelSkinPrefab;
    }
}


public enum WeaponType
{
    KNIFE = 0,
    SHIELD = 1,
    AXE_01 = 2,

    AXE_02 = 3,

    NONE = 99
}