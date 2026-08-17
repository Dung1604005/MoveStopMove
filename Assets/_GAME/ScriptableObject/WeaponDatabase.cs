using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDatabase", menuName = "Scriptable Objects/WeaponDatabase")]
public class WeaponDatabase : ScriptableObject
{
    [SerializeField] private List<WeaponDataSO> listWeaponData = new List<WeaponDataSO>();



    public WeaponDataSO GetWeaponData(int weaponId)
    {
        return listWeaponData[weaponId];
    }
}
