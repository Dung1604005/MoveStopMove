using System;
using UnityEngine;

public class Character : GameUnit
{
    [SerializeField] protected CharacterStat stat;

    [SerializeField] protected Animator anim;

    [SerializeField] protected CharacterCombat combat;

    public CharacterStat GetStat() {return stat;}

    public CharacterCombat GetCombat() {return combat;}

    protected String currentAnim;

    public void OnInit()
    {
        stat.OnInit();
        combat.OnInit();
    }


    public void OnDespawn()
    {
        
    }

    public virtual bool IsStop()
    {
        return false;
    }

    public virtual void Move()
    {
        
    }

    public float CaculateSquaredDistance(Transform tf)
    {
        return (this.tf.position - tf.position).sqrMagnitude;
    }

    public Vector3 CaculateDir(Transform tf)
    {
        return (this.tf.position - tf.position).normalized;
    }

    public void ChangeAnim(String animName)
    {
        anim.ResetTrigger(currentAnim);

        currentAnim = animName;

        anim.SetTrigger(animName);
    }


}
