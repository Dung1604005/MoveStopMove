using UnityEngine;

[CreateAssetMenu(fileName = "SkinDataSO", menuName = "Scriptable Objects/SkinDataSO")]
public class SkinDataSO : ScriptableObject
{
    [SerializeField] private int skinId;

    [SerializeField] private SkinType skinType;

    [SerializeField] private float rangeBuff;

    [SerializeField] private float atkSpdBuff;

    [SerializeField] private float speedBuff;

    public int SkinId => skinId;

    public SkinType SkinType => skinType;

    public float RangeBuff => rangeBuff;

    public float AtkSpdBuff => atkSpdBuff;

    public float SpeedBuff => speedBuff;

    public virtual void ApplyBuff(CharacterStat stat)
    {
        stat.SetAtkSpd(stat.AtkSpd + atkSpdBuff);

        stat.SetRangeAtk(stat.RangeAtk + rangeBuff);

        stat.SetSpeed(stat.Speed + speedBuff);
    }

    public virtual void RemoveBuff(CharacterStat stat)
    {
        stat.SetAtkSpd(stat.AtkSpd - atkSpdBuff);

        stat.SetRangeAtk(stat.RangeAtk - rangeBuff);

        stat.SetSpeed(stat.Speed - speedBuff);
    }

    public virtual void ChangeVisualSkin(Character character)
    {
        
    }

    public virtual void RemoveVisualSkin(Character character)
    {
        
    }
}


public enum SkinType
{
    PANT,
    HAT
}