using System;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
   [SerializeField] private float healthBase;

   [SerializeField] private float currentHealth;
   [SerializeField] private float speedBase;

   [SerializeField] private float speedBuff;
   [SerializeField] private int level;

   [SerializeField] private float sizeBase;

   [SerializeField] private float sizeBuff;

   [SerializeField] private float atkSpdBase;

   [SerializeField] private float atkSpdBuff;

   [SerializeField] private float rangeAtkBase;

   [SerializeField] private float rangeAtkBuff;

   [SerializeField] private float atkBase;

   [SerializeField] private float atkBuff;

   public float GetSpeed() {return speedBase + speedBuff;}

   public float GetSize() {return sizeBase + sizeBuff;}

   public float GetAtkSpd() {return atkSpdBase + atkSpdBuff;}

   public float GetRangeAtk() {return rangeAtkBase + rangeAtkBuff;}

   public float GetAtk(){return atkBase + atkBuff;}

   public void SetSpeedBuff(float buff){speedBuff = buff;}

   public void SetSizeBuff(float buff){sizeBuff = buff;}

   public void SetAtkSpdBuff(float buff){atkSpdBuff = buff;}

   public void SetRangeAtkBuff(float buff){rangeAtkBuff = buff;}

   public void SetAtkBuff(float buff){atkBuff = buff;}

   public void SetLevel(int _level){level = _level;}

   public int GetLevel(){return level;}

   public float SpeedBuff => speedBuff;

   public float SizeBuff => sizeBuff;

   public float AtkSpdBuff => atkSpdBuff;

   public float RangeAtkBuff => rangeAtkBuff;

   public float AtkBuff => atkBuff;

   public bool IsDead => currentHealth <= 0;

   public void OnInit()
    {
        level = 0;
        sizeBuff = 0f;
        speedBuff = 0f;
        atkSpdBuff = 0f;
        atkBuff = 0f;
        rangeAtkBuff = 0f;
        currentHealth = healthBase;
    }

    public void OnHit(float damage)
    {
        currentHealth = Mathf.Max(0f, currentHealth - damage);
    }


}
