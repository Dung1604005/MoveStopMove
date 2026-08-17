using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Scriptable Objects/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField] private int weaponId;

    [SerializeField] private float rangeBuff;

    [SerializeField] private float cooldown;

    [SerializeField] private float atkBuff;

    [SerializeField] private float moveSpeedBullet;

    public int WeaponId => weaponId;

    public float RangeBuff => rangeBuff;


    public float AtkBuff => atkBuff;

    public float Cooldown => cooldown;

    public float MoveSpeedBullet => moveSpeedBullet;

    public void ApplyBuff(CharacterStat stat)
    {
        stat.SetRangeAtk(stat.RangeAtk + rangeBuff);

        stat.SetAtk(stat.Atk + atkBuff);
    }
}
