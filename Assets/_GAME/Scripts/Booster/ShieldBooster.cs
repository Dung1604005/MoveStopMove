using UnityEngine;

public class ShieldBooster : BoosterBase
{
     public override void ApplyBuff(Character character)
    {
        character.GetStat().ActiveUniqueStat(UniqueStatType.HAVE_SHIELD,CharacterVFXType.SHIELD, duration);
    }
}
