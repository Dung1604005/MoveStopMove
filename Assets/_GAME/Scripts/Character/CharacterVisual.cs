using System.Collections.Generic;
using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    [SerializeField] private CharacterStat stat;
    [SerializeField] private Transform tf;

    [SerializeField] protected Renderer pantRenderer;

    [SerializeField] protected DetailSkinType currentPant;

    [SerializeField] protected Transform hatSkinHolder;

    [SerializeField] protected GameUnit hatPrefab;

    [SerializeField] protected DetailSkinType currentHat;

    public void OnInit()
    {
        EquipHat(DataManager.Instance.SkinDatabase.GetRandomHat());

        EquipPant(DataManager.Instance.SkinDatabase.GetRandomPant());
    }

    public void SetSize(float size)
    {
        tf.localScale = Vector3.one*size;
    }

    public void ChangePantVisual(DetailSkinType pantType)
    {
        PantSkinDataSO pantData = DataManager.Instance.SkinDatabase.GetSkinData<PantSkinDataSO>(pantType);
        pantRenderer.sharedMaterial = pantData.GetPantMat();
    }
    public void ChangeHatVisual(DetailSkinType hatType)
    {
        Destroy(hatPrefab?.gameObject);
        if(hatType != DetailSkinType.HAT_NONE)
        {
            HatSkinDataSO hatSkinData = DataManager.Instance.SkinDatabase.GetSkinData<HatSkinDataSO>(hatType);
            hatPrefab = Instantiate(hatSkinData.HatPrefab, hatSkinHolder.position + hatSkinData.SpawnPos, hatSkinHolder.rotation, hatSkinHolder );
        }       
    }
    public void ApplyChangeStatSkin(SkinDataSO skinDataSO)
    {
        stat.SetRangeAtk(stat.RangeAtk + skinDataSO.RangeBuff);

        stat.SetAtkSpd(stat.AtkSpd + skinDataSO.AtkSpdBuff);

        stat.SetSpeed(stat.Speed + skinDataSO.SpeedBuff);
    }

    public void EquipHat(DetailSkinType hatType)
    {
        currentHat = hatType;
        ApplyChangeStatSkin(DataManager.Instance.SkinDatabase.GetSkinData<HatSkinDataSO>(hatType));
    
        ChangeHatVisual(hatType);
    }

    public void EquipPant(DetailSkinType pantType)
    {
        currentPant = pantType;
        ApplyChangeStatSkin(DataManager.Instance.SkinDatabase.GetSkinData<PantSkinDataSO>(pantType));
    
        ChangePantVisual(pantType);
    }


}
