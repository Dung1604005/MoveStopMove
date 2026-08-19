using UnityEngine;
public abstract class SkinDataSO : ScriptableObject
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

}


public enum SkinType
{
    PANT,
    HAT
}