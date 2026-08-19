using System.Collections.Generic;
using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    [SerializeField] private CharacterStat stat;
    [SerializeField] private Transform tf;

    [SerializeField] protected Renderer pantRenderer;

    [SerializeField] protected PantType currentPant;

    [SerializeField] protected Transform hatSkinHolder;

    [SerializeField] protected GameUnit hatPrefab;

    [SerializeField] protected HatType currentHat;

    public void SetSize(float size)
    {
        tf.localScale = Vector3.one*size;
    }

    public void ChangePantVisual(PantType pantType)
    {
        PantSkinDataSO pantData = DataManager.Instance.PantSkinDatabase.GetPantData(pantType);
        pantRenderer.sharedMaterial = pantData.GetPantMat();
    }
    public void ChangeHatVisual(HatType hatType)
    {
        Destroy(hatPrefab.gameObject);
        if(hatType != HatType.NONE)
        {
            HatSkinDataSO hatSkinData = DataManager.Instance.HatSkinDatabase.GetHatData(hatType);
            hatPrefab = Instantiate(hatSkinData.HatPrefab, hatSkinHolder.position + hatSkinData.SpawnPos, hatSkinHolder.rotation );
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
        ApplyChangeStatSkin(DataManager.Instance.HatSkinDatabase.GetHatData(hatType));
    
        ChangeHatVisual(hatType);
    }

    public void EquipPant(PantType pantType)
    {
        currentPant = pantType;
        ApplyChangeStatSkin(DataManager.Instance.PantSkinDatabase.GetPantData(pantType));
    
        ChangePantVisual(pantType);
    }
}
