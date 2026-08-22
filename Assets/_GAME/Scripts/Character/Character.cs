using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameUnit
{
    [SerializeField] protected CharacterStat stat;

    [SerializeField] protected Animator anim;

    [SerializeField] protected CharacterCombat combat;

    [SerializeField] protected CharacterDetector characterDetector;

    [SerializeField] protected CharacterVisual characterVisual;

    [SerializeField] protected CharacterEffect characterEffect;


    [SerializeField] protected float rotationSpeed;

    [SerializeField] protected bool isPlayer;

    [SerializeField] protected List<SkinDataSO> equipedSkins = new List<SkinDataSO>();

    private Quaternion targetRotation = Quaternion.identity;

    public CharacterStat GetStat() { return stat; }

    public CharacterCombat GetCombat() { return combat; }

    public CharacterDetector GetDetector(){return characterDetector;}

    public CharacterVisual GetVisual() {return characterVisual;}

    public CharacterEffect GetEffect() {return characterEffect;}

    public bool IsPlayer => isPlayer;

    protected String currentAnim;

    public virtual void OnInit()
    {
       
        stat.OnInit();
        combat.OnInit();
        characterDetector.OnInit();
        characterVisual.OnInit();
    }


    public virtual void OnDespawn()
    {
        //SimplePool.Despawn(this);
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

        Vector3 thisTFNoY = new Vector3(this.tf.position.x, 0f, this.tf.position.z);
        Vector3 targetTFNoY = new Vector3(tf.position.x, 0f, tf.position.z);


        return (thisTFNoY - targetTFNoY).sqrMagnitude;
    }

    public Vector3 CaculateDir(Transform tf)
    {
        Vector3 thisTFNoY = new Vector3(this.tf.position.x, 0f, this.tf.position.z);
        Vector3 targetTFNoY = new Vector3(tf.position.x, 0f, tf.position.z);
        return (-thisTFNoY + targetTFNoY).normalized;

    }
    public void SetTargetRotation(Vector3 dir)
    {
        targetRotation = Quaternion.LookRotation(dir.normalized);
    }

    public void ChangeRotation()
    {
        tf.rotation = Quaternion.Slerp(tf.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void ChangeAnim(String animName)
    {
        anim.ResetTrigger(currentAnim);

        currentAnim = animName;

        anim.SetTrigger(animName);
    }

    protected virtual void Awake()
    {
        OnInit();
    }

    protected virtual void Update()
    {
        if(stat.IsDead) return;

        combat.CombatUpdate();
    }


}
