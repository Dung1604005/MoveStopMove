using System;
using UnityEngine;
public abstract class SkinDataSO : ScriptableObject
{
    [SerializeField] private float rangeBuff;

    [SerializeField] private float atkSpdBuff;

    [SerializeField] private float speedBuff;

    [SerializeField] private Sprite skinPortrait;


    public float RangeBuff => rangeBuff;

    public float AtkSpdBuff => atkSpdBuff;

    public float SpeedBuff => speedBuff;
    public Sprite GetSprite()
    {
        return skinPortrait;
    }

    


}

[Serializable]
public enum SkinType
{
    PANT = 0,
    HAT = 1
}