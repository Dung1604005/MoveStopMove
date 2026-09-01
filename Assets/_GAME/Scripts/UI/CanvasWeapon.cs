using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasWeapon : UICanvas
{
    [SerializeField] private TextMeshProUGUI nameWeaponTxt;

    [SerializeField] private WeaponType currentWeapon;

    [SerializeField] private int currentSkinId = -1;

    [SerializeField] private Transform skinSlotHolder;

    [SerializeField] private List<UISkinSlot> skinSlots = new List<UISkinSlot>();

    [SerializeField] private UISkinSlot skinSlotPrefab ;



    public override void CloseDirectly()
    {
        ClearSkinSlots();
        base.CloseDirectly();
    }

    public override void SetUp()
    {
        base.SetUp();
        SetUpWeaponInfo(WeaponType.KNIFE);
        
        
    }

    public void ClearSkinSlots()
    {
        currentSkinId = -1;
        for(int i= 0; i < skinSlots.Count; i++)
        {
            Destroy(skinSlots[i].gameObject);
        }
        skinSlots.Clear();
    }

    public void GenerateSkinSlots()
    {
        WeaponDataSO weaponDataSO = DataManager.Instance.WeaponDatabase.GetWeaponData(currentWeapon);
        for(int i = 0; i < weaponDataSO.GetTotalSkin(); i++)
        {
            UISkinSlot uISkinSlot = Instantiate(skinSlotPrefab, skinSlotHolder);

            uISkinSlot.SetUpInfo(weaponDataSO.GetWeaponSkinData(i));

            skinSlots.Add(uISkinSlot);
        }
    }
    public void OnButtonNext()
    {
        int nextWeapon = ((int)currentWeapon + 1)%(DataManager.Instance.WeaponDatabase.GetCountWeapon());

        SetUpWeaponInfo((WeaponType)nextWeapon);
    }
    public void OnButtonBack()
    {
        int prevWeapon = ((int)currentWeapon - 1 + DataManager.Instance.WeaponDatabase.GetCountWeapon())%(DataManager.Instance.WeaponDatabase.GetCountWeapon());

        SetUpWeaponInfo((WeaponType) prevWeapon);
    }

    public void ChangeWeaponName(String nameWeapon)
    {
        nameWeaponTxt.text = nameWeapon;
    }

    public void SetUpWeaponInfo(WeaponType newWeapon)
    {
        ClearSkinSlots();
        currentWeapon = newWeapon;
        ChangeWeaponName(DataManager.Instance.WeaponDatabase.GetWeaponData(newWeapon).NameWeapon);
        GameManager.Instance.GetModelShowcase().ChangeWeaponModel(currentWeapon);
        GenerateSkinSlots();
        SetCurrentSkinEquiped(0);

    }

    public void ChangeWeaponSkin()
    {
        WeaponDataSO weaponDataSO = DataManager.Instance.WeaponDatabase.GetWeaponData(currentWeapon);
        GameManager.Instance.GetModelShowcase().ChangeWeaponSkin(weaponDataSO.GetWeaponSkinData(currentSkinId));
    }

    public void SetCurrentSkinEquiped(int skinId)
    {
        if(skinId == currentSkinId)return;
        int lastEquipedSkin = currentSkinId;
        if(lastEquipedSkin >= 0)
        {
            Debug.Log(lastEquipedSkin);
            skinSlots[lastEquipedSkin].SetActiveSelectedEffect(false);
        }
        currentSkinId = skinId;
        skinSlots[currentSkinId].SetActiveSelectedEffect(true);
        ChangeWeaponSkin();
    }

}
