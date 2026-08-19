using UnityEngine;

public class WeaponBase : GameUnit
{
    [SerializeField] private Character owner;

    [SerializeField] private WeaponDataSO weaponDataSO;

    [SerializeField] private Transform posSpawnTf;

    [SerializeField] private Transform visualTf;

    public virtual void OnInit()
    {
        
    }

    public void SetActiveVisual(bool active)
    {
        visualTf.gameObject.SetActive(active);
    }

    public float CaculateCoolDown(float atkSpeed)
    {
        float coolDownTime =  weaponDataSO.Cooldown;
        coolDownTime = coolDownTime/atkSpeed;
        return coolDownTime;
    }

    public virtual void StartAttack(Vector3 dir)
    {
        BulletBase bulletBase = SimplePool.Spawn<BulletBase>(PoolType.BulletPool, TF.position, tf.rotation);

        bulletBase.LoadData(dir, weaponDataSO.MoveSpeedBullet, owner.GetStat().Atk, owner);

        SetActiveVisual(false);
    }
}
