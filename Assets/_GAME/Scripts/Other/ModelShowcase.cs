using UnityEngine;

public class ModelShowcase : MonoBehaviour
{
    [SerializeField] private Camera modelCamera;

    [SerializeField] private Transform weaponHolder;

    [SerializeField] private WeaponSkin weaponSkinPrefab;

    [SerializeField] private WeaponType currentWeaponType;

    [SerializeField] private CharacterVisual characterModel;

    public void ChangeWeaponModel(WeaponType weaponType)
    {
        WeaponDataSO weaponDataSO = DataManager.Instance.WeaponDatabase.GetWeaponData(weaponType);
        DespawnWeaponModel();
        if(weaponType != currentWeaponType)
        {
            currentWeaponType = weaponType;
            SpawnWeaponModel(weaponDataSO.GetModelWeaponPrefab());
        }
    }

    public void ChangeWeaponSkin(WeaponSkinData weaponSkinData)
    {
        weaponSkinPrefab.ChangeSkin(weaponSkinData);
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

    public void SetActiveCharacterModel(bool active)
    {
        characterModel.gameObject.SetActive(active);
    }

    public void ChangePantModel(PantType pantType)
    {
        characterModel.ChangePantVisual(pantType);
    }

    public void ChangeHatModel(HatType hatType)
    {
        characterModel.ChangeHatVisual(hatType); 
    }
}
