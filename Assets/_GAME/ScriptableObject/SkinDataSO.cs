using UnityEngine;
public abstract class SkinDataSO : ScriptableObject
{
    [SerializeField] private float rangeBuff;

    [SerializeField] private float atkSpdBuff;

    [SerializeField] private float speedBuff;


    public float RangeBuff => rangeBuff;

    public float AtkSpdBuff => atkSpdBuff;

    public float SpeedBuff => speedBuff;

}


public enum SkinType
{
    PANT,
    HAT
}