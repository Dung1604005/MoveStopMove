using UnityEngine;

public class ModelShowcase : MonoBehaviour
{
    [SerializeField] private Camera modelCamera;

    [SerializeField] private Transform weaponHolder;

    [SerializeField] private WeaponSkin weaponSkinPrefab;

    [SerializeField] private WeaponType currentWeaponType;

    public void ChangeWeaponModel(WeaponDataSO weaponDataSO)
    {
        DespawnWeaponModel();
        if(weaponDataSO.WeaponType != currentWeaponType)
        {
            SpawnWeaponModel(weaponDataSO.GetModelWeaponPrefab());
        }
    }

    public void DespawnWeaponModel()
    {
        if(weaponSkinPrefab != null && weaponSkinPrefab.gameObject != null)
        {
            Destroy(weaponSkinPrefab.gameObject);
        }
    }
    public void SpawnWeaponModel(WeaponSkin prefab)
    {
        weaponSkinPrefab = Instantiate(prefab, weaponHolder);
    }
}
