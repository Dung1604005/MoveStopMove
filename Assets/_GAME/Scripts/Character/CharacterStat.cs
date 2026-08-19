using System;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private float healthBase;

    [SerializeField] private float currentExp;

    [SerializeField] private float currentHealth;
    [SerializeField] private float speed;
    [SerializeField] private int level;

    [SerializeField] private float size;

    [SerializeField] private float atkSpd;

    [SerializeField] private float rangeAtk;

    [SerializeField] private float atk;

    public float GetCurrentHealth() { return currentHealth; }

    public void SetSpeed(float _speed) { speed = _speed; }

    public void SetAtkSpd(float _atkSpd) { atkSpd = _atkSpd; }

    public void SetRangeAtk(float _rangeAtk)
    {
        rangeAtk = _rangeAtk;
        character.GetDetector().SetSizeRange(rangeAtk);
    }

    public void SetSize(float _size)
    {
        size = _size;
        character.GetVisual().SetSize(size);
    }

    public void SetAtk(float _atk) { atk = _atk; }

    public void SetLevel(int _level) { level = _level; }

    public int Level => level;

    public float Speed => speed;

    public float Size => size;

    public float AtkSpd => atkSpd;

    public float RangeAtk => rangeAtk;

    public float Atk => atk;

    public bool IsDead => currentHealth <= 0.01f;

    public float ExpRequireToLvUp => GameConfig.BASE_EXP * Mathf.Pow(GameConfig.EXP_GROWTHRATE, level);

    public void OnInit()
    {
        level = 1;
        size = 1;
        // speed = 0f;
        // atkSpd = 0f;
        // atk = 0f;
        // rangeAtk = 0f;
        currentExp = 0f;
        currentHealth = healthBase;
    }

    public void OnDead(Character attacker)
    {
        attacker.GetStat().GainExp(GameConfig.EXP_GAIN_PER_LEVEL * level);
        character.ChangeAnim(GameConfig.ANIM_DEAD);
        Invoke(nameof(OnDespawn), 2f);
    }
    public void OnDespawn()
    {
        character.OnDespawn();
    }
    public void OnHit(float damage, Character attacker)
    {
        if (IsDead) return;
        currentHealth = Mathf.Max(0f, currentHealth - damage);
        if (IsDead)
        {
            OnDead(attacker);
        }
    }

    public void GainExp(float exp)
    {
        currentExp += exp;

        for (int i = 1; i <= 100; i++)
        {
            if (currentExp >= ExpRequireToLvUp)
            {
                currentExp -= ExpRequireToLvUp;
                LevelUp();
            }
            else
            {
                break;
            }
        }



    }

    public void LevelUp()
    {
        if (character.IsPlayer)
        {
            GameManager.Instance.MainCameraFollow.UpOffset();
        }
        SetLevel(level + 1);

        SetAtk(atk + GameConfig.ATK_GROWTH);

        SetRangeAtk(rangeAtk + GameConfig.RANGE_GROWTH);

        SetSize(size + GameConfig.SIZE_GROWTHRATE);
    }


}
