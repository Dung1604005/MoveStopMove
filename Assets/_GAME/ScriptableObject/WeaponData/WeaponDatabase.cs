using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDatabase", menuName = "Scriptable Objects/Weapon/WeaponDatabase")]
public class WeaponDatabase : ScriptableObject
{
    [SerializeField] private List<WeaponDataSO> listWeaponData = new List<WeaponDataSO>();

    public int GetCountWeapon()
    {
        return listWeaponData.Count;
    }

    public WeaponDataSO GetWeaponData(WeaponType weaponType)
    {
        return listWeaponData[(int)weaponType];
    }

    public WeaponBase GetRandomWeaponPrefab()
    {
        int randomWeapon = Random.Range(0, listWeaponData.Count);
        return listWeaponData[randomWeapon].GetWeaponPrefab();
    }
}
