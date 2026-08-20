using UnityEngine;

public class HealBooster : BoosterBase
{
    [SerializeField] private float healAmount;


    public override void ApplyBuff(Character character)
    {
        character.GetStat().Heal(healAmount);
    }
}
