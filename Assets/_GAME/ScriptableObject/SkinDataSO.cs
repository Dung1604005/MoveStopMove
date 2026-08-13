using UnityEngine;

[CreateAssetMenu(fileName = "SkinDataSO", menuName = "Scriptable Objects/SkinDataSO")]
public class SkinDataSO : ScriptableObject
{
    [SerializeField] private int skinId;

    [SerializeField] private float rangeBuff;

    [SerializeField] private float atkSpdBuff;

    [SerializeField] private float speedBuff;

    public int SkinId => skinId;

    public float RangeBuff => rangeBuff;

    public float AtkSpdBuff => atkSpdBuff;

    public float SpeedBuff => speedBuff;

    public void ApplyBuff(CharacterStat stat)
    {
        stat.SetAtkSpdBuff(stat.AtkSpdBuff + atkSpdBuff);

        stat.SetRangeAtkBuff(stat.RangeAtkBuff + rangeBuff);

        stat.SetSpeedBuff(stat.SpeedBuff + speedBuff);
    }
}
