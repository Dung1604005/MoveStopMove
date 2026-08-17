using System;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
   [SerializeField] private float healthBase;

   [SerializeField] private float currentHealth;
   [SerializeField] private float speed;
   [SerializeField] private int level;

   [SerializeField] private float size;

   [SerializeField] private float atkSpd;

   [SerializeField] private float rangeAtk;

   [SerializeField] private float atk;

   public float GetSpeed() {return speed;}

   public float GetSize() {return size;}

   public float GetAtkSpd() {return atkSpd;}

   public float GetRangeAtk() {return rangeAtk;}

   public float GetAtk(){return atk;}

   public void SetSpeed(float _speed){speed = _speed;}

   public void SetAtkSpd(float _atkSpd){atkSpd = _atkSpd;}

   public void SetRangeAtk(float _rangeAtk){rangeAtk = _rangeAtk;}

   public void SetAtk(float _atk){atk = _atk;}

   public void SetLevel(int _level){level = _level;}

   public int GetLevel(){return level;}

   public float Speed => speed;

   public float AtkSpd => atkSpd;

   public float RangeAtk => rangeAtk;

   public float Atk => atk;

   public bool IsDead => currentHealth <= 0;

   public void OnInit()
    {
        // level = 0;
        // speed = 0f;
        // atkSpd = 0f;
        // atk = 0f;
        // rangeAtk = 0f;
        currentHealth = healthBase;
    }

    public void OnHit(float damage)
    {
        currentHealth = Mathf.Max(0f, currentHealth - damage);
    }


}
