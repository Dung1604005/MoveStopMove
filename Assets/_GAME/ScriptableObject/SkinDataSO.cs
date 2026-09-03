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

    public String GetAllStatDescription()
    {
        String result = "";
        result = result + GetStatDescription(rangeBuff, "Range Atk");

        result = result + GetStatDescription(atkSpdBuff, "Atk Spd");

        result = result + GetStatDescription(speedBuff, "Speed");
        return result;
    }

    public String GetStatDescription(float stat, String nameStat)
    {
        String result = "";
        if(stat > 0.01f)
        {
            result = nameStat + " + " + stat.ToString()+"\n";
        }

        return result;
    }

    


}

[Serializable]
public enum SkinType
{
    PANT = 0,
    HAT = 1
}