using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CanvasSkin : UICanvas
{
    [SerializeField] private UISkinSlot skinSlotPrefab;
    [SerializeField] private SkinType currentSkinType;
    [SerializeField] private List<SkinTabGroup> skinTabs = new List<SkinTabGroup>();

    [SerializeField] private TextMeshProUGUI nameTxt;

    [SerializeField] private TextMeshProUGUI statDestxt;

    [SerializeField] private GameObject buyButton;
    private Dictionary<SkinType, SkinTabGroup> tabLookup;

    private void Awake()
    {
        OnInit();
    }

    private void OnInit()
    {
        tabLookup = new Dictionary<SkinType, SkinTabGroup>();
        foreach (var tab in skinTabs)
        {
            tabLookup[tab.skinType] = tab;
        }
    }

    public override void SetUp()
    {
        base.SetUp();
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
        tab.currentSelectedId = -1;
    }
    private void CreateSlots(SkinType type, int totalCount, Func<int, Sprite> getSpriteFunc)
    {
        SkinTabGroup tab = tabLookup[type];

        ClearTabSlots(tab);

        for (int i = 0; i < totalCount; i++)
        {
            UISkinSlot slot = Instantiate(skinSlotPrefab, tab.holder);
            slot.SetUpInfo(i, getSpriteFunc(i));
            slot.SetParentCanvas(this);
            tab.slots.Add(slot);
        }
    }
    public void SetUpSkin()
    {
         switch (currentSkinType)
        {
            case SkinType.PANT:
                SetUpPantSlots();
                break;
            case SkinType.HAT:
                SetUpHatSlots();
                break;
        }
    }

    public void SetUpPantSlots()
    {
        var pantDB = DataManager.Instance.PantDatabase;
        CreateSlots(SkinType.PANT, pantDB.GetTotalNumberPant(), i => pantDB.GetPantData((PantType)i).GetSprite());
    }

    public void SetUpHatSlots()
    {
        var hatDB = DataManager.Instance.HatDatabase;
        CreateSlots(SkinType.HAT, hatDB.GetTotalNumberHat(), i => hatDB.GetHatData((HatType)i).GetSprite());
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

        SetUpSkin();
    }

    public void OnBuyButton()
    {
        
    }

    public void OnBackButton()
    {
        
    }
}
[Serializable]
public class SkinTabGroup
{
    public Transform tf;
    public SkinType skinType;
    public Transform holder;
    public List<UISkinSlot> slots = new List<UISkinSlot>();
    public int currentSelectedId = -1;

    public void SetActiveSkinTab(bool active)
    {
        tf.gameObject.SetActive(active);
    }
}