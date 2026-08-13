using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameUnit
{
    [SerializeField] protected CharacterStat stat;

    [SerializeField] protected Animator anim;

    [SerializeField] protected CharacterCombat combat;

    [SerializeField] protected Renderer pantRenderer;

    [SerializeField] protected PantType currentPant;

    [SerializeField] protected float rotationSpeed;

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
    public virtual void StopMove()
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

    public void ChangeRotation(Vector3 dir)
    {
        Quaternion targetRotation = Quaternion.LookRotation(dir.normalized);
        tf.rotation = Quaternion.Slerp(tf.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    public void ChangePant(PantType pantType)
    {
        currentPant = pantType;

        pantRenderer.materials[0] = DataManager.Instance.PantMatDataSO.GetPantMat(pantType); 
    }

    public void ApplySkinData(SkinDataSO skinDataSO)
    {
        skinDataSO.ApplyBuff(stat);
    }

    public void ChangeAnim(String animName)
    {
        anim.ResetTrigger(currentAnim);

        currentAnim = animName;

        anim.SetTrigger(animName);
    }


}
