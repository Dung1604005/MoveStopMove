using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] private WeaponDataSO weaponDataSO;

    public virtual void OnInit()
    {
        
    }

    public float CaculateCoolDown(float atkSpeed)
    {
        float coolDownTime =  weaponDataSO.Cooldown;
        coolDownTime = coolDownTime/atkSpeed;
        return coolDownTime;
    }

    public virtual void StartAttack(Vector3 dir)
    {
        
    }

    public virtual void SpawnAttack()
    {
        
    }
}
