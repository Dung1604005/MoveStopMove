using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasWeapon : UICanvas
{
    [SerializeField] private TextMeshProUGUI nameWeaponTxt;

    [SerializeField] private TextMeshProUGUI descriptionTxt;

    [SerializeField] private TextMeshProUGUI priceTxt;

    [SerializeField] private WeaponType currentWeapon;

    [SerializeField] private int currentSkinId = -1;

    [SerializeField] private Transform skinSlotHolder;

    [SerializeField] private List<UISkinSlot> skinSlots = new List<UISkinSlot>();

    [SerializeField] private UISkinSlot skinSlotPrefab;

    [SerializeField] private GameObject buyButton;

    public override void CloseDirectly()
    {
        ClearSkinSlots();
        GameManager.Instance.GetModelShowcase().DespawnWeaponModel();
        base.CloseDirectly();
    }

    public override void SetUp()
    {
        base.SetUp();
        GameManager.Instance.GetModelShowcase().SetActiveCharacterModel(false);
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

    public void ReloadAllSkinSlot()
    {
        for(int i = 0; i < skinSlots.Count; i++)
        {
            skinSlots[i].Reload(currentWeapon);
        }
    }

    public void GenerateSkinSlots()
    {
        WeaponDataSO weaponDataSO = DataManager.Instance.WeaponDatabase.GetWeaponData(currentWeapon);
        for(int i = 0; i < weaponDataSO.GetTotalSkin(); i++)
        {
            UISkinSlot uISkinSlot = Instantiate(skinSlotPrefab, skinSlotHolder);

            uISkinSlot.SetUpInfo(i, weaponDataSO.GetWeaponSkinData(i).GetSpriteUI());
            uISkinSlot.SetParentCanvas(this);
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

    public void OnButtonClose()
    {
        UIManager.Instance.CloseUIDirectly<CanvasWeapon>();

        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }

    public void OnButtonBuy()
    {
        int price = DataManager.Instance.WeaponDatabase.GetWeaponData(currentWeapon).GetWeaponSkinData(currentSkinId).Price;
        if (DataManager.Instance.PlayerDataController.CanAfford(price))
        {
            DataManager.Instance.PlayerDataController.AddNewSkinWeaponUnlock(currentWeapon, currentSkinId);
            DataManager.Instance.PlayerDataController.ChangeGold(-price);
            SetActiveBuyFunc(false);
            DataManager.Instance.PlayerDataController.UpdateCurrentSkinWeaponChoosed(currentWeapon, currentSkinId);
            
        }
    }

    public void SetActiveBuyFunc(bool active)
    {
        buyButton.SetActive(active);
    }

    public void SetInfomationWeapon(WeaponDataSO weaponData)
    {
        ChangeWeaponName(weaponData.NameWeapon);
        SetStatDescription(weaponData.GetAllStatDescription());
    }

    public void ChangeWeaponName(String nameWeapon)
    {
        nameWeaponTxt.text = nameWeapon;
    }

    public void SetStatDescription(String desc)
    {
        descriptionTxt.text = desc;
    }

    public void SetPrice(int price)
    {
        priceTxt.text = price.ToString();
    }

    public void SetUpWeaponInfo(WeaponType newWeapon)
    {
        ClearSkinSlots();
        
        currentWeapon = newWeapon;
        SetInfomationWeapon(DataManager.Instance.WeaponDatabase.GetWeaponData(newWeapon));
        GameManager.Instance.GetModelShowcase().ChangeWeaponModel(currentWeapon);
        GenerateSkinSlots();
        ReloadAllSkinSlot();
        SetCurrentSkinEquiped(DataManager.Instance.PlayerDataController.GetCurrentEquipedSkinWeapon(currentWeapon));
    }

    public void ChangeWeaponSkin()
    {
        WeaponDataSO weaponDataSO = DataManager.Instance.WeaponDatabase.GetWeaponData(currentWeapon);
        GameManager.Instance.GetModelShowcase().ChangeWeaponSkin(weaponDataSO.GetWeaponSkinData(currentSkinId));
    }

    public void SetCurrentSkinEquiped(int skinId)
    {
        if(skinId == currentSkinId)return;
        currentSkinId = skinId;
        ReloadAllSkinSlot();
        ChangeWeaponSkin();
        SetPrice(DataManager.Instance.WeaponDatabase.GetWeaponData(currentWeapon).GetWeaponSkinData(skinId).Price);
        bool isUnlocked = DataManager.Instance.PlayerDataController.IsThisSkinWeaponUnlock(currentWeapon, currentSkinId);
        SetActiveBuyFunc(!isUnlocked);
        if (isUnlocked)
        {
            DataManager.Instance.PlayerDataController.UpdateCurrentSkinWeaponChoosed(currentWeapon, currentSkinId);
        }


    }




}
