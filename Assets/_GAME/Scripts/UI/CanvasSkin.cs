using System;
using System.Collections.Generic;
using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UIElements;

public class CanvasSkin : UICanvas
{
    [SerializeField] private UISkinSlot skinSlotPrefab;
    [SerializeField] private SkinType currentSkinType;
    [SerializeField] private List<SkinTabGroup> skinTabs = new List<SkinTabGroup>();

    [SerializeField] private TextMeshProUGUI nameTxt;

    [SerializeField] private TextMeshProUGUI priceTxt;

    [SerializeField] private TextMeshProUGUI statDestxt;

    [SerializeField] private GameObject buyButton;
    private Dictionary<SkinType, SkinTabGroup> tabLookup;
    private void OnInit()
    {
        tabLookup = new Dictionary<SkinType, SkinTabGroup>();
        foreach (var tab in skinTabs)
        {
            tabLookup[tab.skinType] = tab;
            tab.currentSelectedId = DataManager.Instance.PlayerDataController.GetCurrentEquipedSkin(tab.skinType);
            ApplySkinModel(tab.skinType, tab.currentSelectedId);
        }
    }

    public override void SetUp()
    {
        base.SetUp();
        OnInit();
        GameManager.Instance.GetModelShowcase().SetActiveCharacterModel(true);
        ChangeSkinType(0);
    }

    public override void CloseDirectly()
    {
        base.CloseDirectly();
        ClearAllSlots();
    }

    public void ClearAllSlots()
    {
        foreach (var tab in skinTabs)
        {
            ClearTabSlots(tab);
        }
    }

    private void ClearTabSlots(SkinTabGroup tab)
    {
        for (int i = 0; i < tab.slots.Count; i++)
        {
            if (tab.slots[i] != null)
            {
                Destroy(tab.slots[i].gameObject);
            }
        }
        tab.slots.Clear();
    }
    private void CreateSlots(SkinType type, int totalCount, Func<int, Sprite> getSpriteFunc, int[] unlockedSkins)
    {
        SkinTabGroup tab = tabLookup[type];

        ClearTabSlots(tab);

        for (int i = 0; i < totalCount; i++)
        {
            UISkinSlot slot = Instantiate(skinSlotPrefab, tab.holder);
            slot.SetUpInfo(i, getSpriteFunc(i));
            slot.SetParentCanvas(this);
            slot.SetActiveLockedEffect(true);
            tab.slots.Add(slot);
        }
        for(int i = 0; i < unlockedSkins.Length; i++)
        {
            tab.slots[unlockedSkins[i]].SetActiveLockedEffect(false);
        }
        if (tab.currentSelectedId >= 0 && tab.currentSelectedId < tab.slots.Count)
        {
            tab.slots[tab.currentSelectedId].SetActiveSelectedEffect(true);
        }
        SetUpSkinStat();
    }
    public void SetUpSkinVisual()
    {
        SetUpSkinSlots(currentSkinType);
    }

    public void SetUpSkinStat()
    {
        
        if(tabLookup[currentSkinType].currentSelectedId == -1)return;

        SkinDataSO skinDataSO = DataManager.Instance.GetSkinDatabase(currentSkinType).GetSkinData(tabLookup[currentSkinType].currentSelectedId);

       
        SetSkinNameText(skinDataSO.GetNameSkin());

        SetStatDescription(skinDataSO.GetAllStatDescription());
    }

    public void SetUpSkinSlots(SkinType skinType)
    {
        var skinDb = DataManager.Instance.GetSkinDatabase(skinType);
        CreateSlots(skinType, skinDb.GetTotalNumberSkin(), i => skinDb.GetSkinData(i).GetSprite(),
        DataManager.Instance.PlayerDataController.GetArrUnlockedSkin(skinType));
    }

    public void SetPriceText(int price)
    {
        priceTxt.text = price.ToString();
    }

    public void SetCurrentSkin(int skinId)
    {
        SkinTabGroup tab = tabLookup[currentSkinType];
        if (tab.currentSelectedId == skinId) return;

        if (tab.currentSelectedId >= 0 && tab.currentSelectedId < tab.slots.Count)
        {
            tab.slots[tab.currentSelectedId].SetActiveSelectedEffect(false);
        }

        tab.currentSelectedId = skinId;
        if (tab.currentSelectedId >= 0 && tab.currentSelectedId < tab.slots.Count)
        {
            tab.slots[tab.currentSelectedId].SetActiveSelectedEffect(true);
        }

        ApplySkinModel(currentSkinType, skinId);
        SetUpSkinStat();
        if(!DataManager.Instance.PlayerDataController.IsThisSkinUnlocked(currentSkinType, skinId))
        {
            SetPriceText(DataManager.Instance.GetSkinDatabase(currentSkinType).GetSkinData(skinId).Price);
        }
    }

    private void ApplySkinModel(SkinType type, int skinId)
    {
        var showcase = GameManager.Instance.GetModelShowcase();
        switch (type)
        {
            case SkinType.PANT:
                showcase.ChangePantModel((PantType)skinId);
                break;
            case SkinType.HAT:
                showcase.ChangeHatModel((HatType)skinId);
                break;
        }
    }

    public void ChangeSkinType(int skinType)
    {
        SkinType oldSkinType = currentSkinType;
        currentSkinType = (SkinType)skinType;

        tabLookup[oldSkinType].SetActiveSkinTab(false);

        tabLookup[currentSkinType].SetActiveSkinTab(true);

        SetUpSkinVisual();
    }

    public void SetSkinNameText(String _nameSkin)
    {
        nameTxt.text = _nameSkin;
    }

    public void SetStatDescription(String description)
    {
        statDestxt.text = description;
    }

    public void OnBuyButton()
    {
        
    }

    public void OnBackButton()
    {
        UIManager.Instance.CloseUIDirectly<CanvasSkin>();
    }
}
[Serializable]
public class SkinTabGroup
{
    public Transform tf;
    public SkinType skinType;
    public Transform holder;

    public ButtonTabSkin buttonTabSkin;
    public List<UISkinSlot> slots = new List<UISkinSlot>();
    public int currentSelectedId = -1;

    public void SetActiveSkinTab(bool active)
    {
        tf.gameObject.SetActive(active);

        buttonTabSkin.SetActiveButton(active);
    }
}