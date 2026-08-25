using UnityEngine;

public class WeaponBase : GameUnit
{
    [SerializeField] private Character owner;

    [SerializeField] private WeaponDataSO weaponDataSO;

    [SerializeField] private Transform visualTf;

    [SerializeField] private BulletBase bulletPrefab;

    public virtual void OnInit()
    {
        SetActiveVisual(true);
        tf.localPosition = weaponDataSO.SpawnPos;
        ApplyBuff(owner.GetStat());
    }
    public void ApplyBuff(CharacterStat stat)
    {
        stat.SetRangeAtk(stat.RangeAtk + weaponDataSO.RangeBuff);

        stat.SetAtk(stat.Atk + weaponDataSO.AtkBuff);
    }

    public void SetActiveVisual(bool active)
    {
        visualTf.gameObject.SetActive(active);
    }

    public void SetOwner(Character character)
    {
        owner = character;
    }

    public float CaculateCoolDown(float atkSpeed)
    {
        float coolDownTime = weaponDataSO.Cooldown;
        coolDownTime = coolDownTime / atkSpeed;
        return coolDownTime;
    }

    public virtual void StartAttack(Vector3 dir)
    {
        BulletBase bulletBase = SimplePool.Spawn(bulletPrefab, TF.position, tf.rotation);

        bulletBase.LoadData(dir, weaponDataSO.MoveSpeedBullet, owner.GetStat().Atk, owner);

        SetActiveVisual(false);
    }
}
