using UnityEngine;

public class CharacterStat : MonoBehaviour
{
   [SerializeField] private float speedBase;

   [SerializeField] private float speedBuff;
   [SerializeField] private int level;

   [SerializeField] private float sizeBase;

   [SerializeField] private float sizeBuff;

   [SerializeField] private float atkSpdBase;

   [SerializeField] private float atkSpdBuff;

   [SerializeField] private float rangeAtkBase;

   [SerializeField] private float rangeAtkBuff;

   public float GetSpeed() {return speedBase + speedBuff;}

   public float GetSize() {return sizeBase + sizeBuff;}

   public float GetAtkSpd() {return atkSpdBase + atkSpdBuff;}

   public float GetRangeAtk() {return rangeAtkBase + rangeAtkBuff;}

   public int GetLevel(){return level;}

   public void SetSpeedBuff(float buff){speedBuff = buff;}

   public void SetSizeBuff(float buff){sizeBuff = buff;}

   public void SetAtkSpdBuff(float buff){atkSpdBuff = buff;}

   public void SetRangeAtkBuff(float buff){rangeAtkBuff = buff;}

   public void SetLevel(int _level){level = _level;}

   public void OnInit()
    {
        level = 0;
        sizeBuff = 0f;
        speedBuff = 0f;
        atkSpdBuff = 0f;
        rangeAtkBuff = 0f;
    }


}
