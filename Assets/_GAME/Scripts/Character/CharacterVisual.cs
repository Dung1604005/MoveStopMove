using System;
using System.Collections.Generic;

using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class CharacterVisual : MonoBehaviour
{
    [SerializeField] private CharacterStat stat;

    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI nameTxt;

    [SerializeField] private Image  levelImage;
    [SerializeField] private RotationConstraint rotationConstraint;
    [SerializeField] private Transform tf;
    [SerializeField] protected Renderer pantRenderer;
    [SerializeField] protected PantType currentPant;
    [SerializeField] protected Transform hatSkinHolder;
    [SerializeField] protected GameUnit hatPrefab;
    [SerializeField] protected HatType currentHat;

    [SerializeField] protected ColorType colorType;

    [SerializeField] protected Renderer skinCharacterRenderer;

    public ColorType ColorType => colorType;
    
    public void OnInit()
    {
        EquipHat((HatType)DataManager.Instance.GetSkinDatabase(SkinType.HAT).GetRandomSkin());
        ChangeColor(DataManager.Instance.ColorDataSO.GetRandomColor());
        EquipPant((PantType)DataManager.Instance.GetSkinDatabase(SkinType.PANT).GetRandomSkin());
        if (rotationConstraint.sourceCount == 0)
        {
            
            ConstraintSource source = new ConstraintSource
            {
                sourceTransform = Camera.main.transform,
                weight = 1f
            };
            rotationConstraint.AddSource(source);
            rotationConstraint.constraintActive = true;
        }
    }

    public void SetSize(float size)
    {
        tf.localScale = Vector3.one * size;
    }

    public void ChangeColor(ColorType _colorType)
    {
        colorType = _colorType;
        skinCharacterRenderer.sharedMaterial = DataManager.Instance.ColorDataSO.GetColorMat(colorType);
        SetLevelImage(DataManager.Instance.ColorDataSO.GetColor(colorType));
    }

    public void ChangePantVisual(PantType pantType)
    {
        PantSkinDataSO pantData = (PantSkinDataSO)DataManager.Instance.GetSkinDatabase(SkinType.PANT).GetSkinData((int)pantType);
        pantRenderer.sharedMaterial = pantData.GetPantMat();
    }
    public void ChangeHatVisual(HatType hatType)
    {
        if(hatPrefab != null && hatPrefab.gameObject != null)
        {
            Destroy(hatPrefab.gameObject);
        }
        if (hatType != HatType.NONE)
        {
            HatSkinDataSO hatSkinData = (HatSkinDataSO)DataManager.Instance.GetSkinDatabase(SkinType.HAT).GetSkinData((int)hatType);
            hatPrefab = Instantiate(hatSkinData.HatPrefab, hatSkinHolder.position + hatSkinData.SpawnPos, hatSkinHolder.rotation, hatSkinHolder);
        }
    }
    public void ApplyChangeStatSkin(SkinDataSO skinDataSO)
    {
        stat.SetRangeAtk(stat.RangeAtk + skinDataSO.RangeBuff);

        stat.SetAtkSpd(stat.AtkSpd + skinDataSO.AtkSpdBuff);

        stat.SetSpeed(stat.Speed + skinDataSO.SpeedBuff);
    }

    public void EquipHat(HatType hatType)
    {
        currentHat = hatType;
        ApplyChangeStatSkin(DataManager.Instance.GetSkinDatabase(SkinType.HAT).GetSkinData((int)hatType));
        ChangeHatVisual(hatType);
    }

    public void EquipPant(PantType pantType)
    {
        currentPant = pantType;
        ApplyChangeStatSkin(DataManager.Instance.GetSkinDatabase(SkinType.PANT).GetSkinData((int)pantType));
        ChangePantVisual(pantType);
    }

    public void SetNameText(String _name)
    {
        nameTxt.text = _name;
    }

    public void SetLevelText(int _level)
    {
        levelTxt.text = _level.ToString();
    }

    public void SetLevelImage(Color _color)
    {
        levelImage.color = _color;
    }


}
