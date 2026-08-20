using UnityEngine;

public class RangeBuffBooster : BoosterBase
{
    [SerializeField] private float rangeBuff;

    public override void ApplyBuff(Character character)
    {
        character.GetStat().SetRangeAtk(character.GetStat().RangeAtk + rangeBuff);
    }
}
