using UnityEngine;

public class LevelUpBooster : BoosterBase
{
    public override void ApplyBuff(Character character)
    {
        base.ApplyBuff(character);
        character.GetStat().LevelUp();
    }
}
