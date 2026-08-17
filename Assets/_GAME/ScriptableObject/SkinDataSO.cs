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
        stat.SetAtkSpd(stat.AtkSpd + atkSpdBuff);

        stat.SetRangeAtk(stat.RangeAtk + rangeBuff);

        stat.SetSpeed(stat.Speed + speedBuff);
    }
}
