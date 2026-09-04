using System;
using System.Collections.Generic;
using UnityEngine;

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

    public void ReloadTab()
    {
        foreach(UISkinSlot uISkinSlot in slots)
        {
            uISkinSlot.Reload(skinType);
        }
    }
}