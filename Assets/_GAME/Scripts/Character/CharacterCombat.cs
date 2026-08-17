using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] protected Character character;
    [SerializeField] protected WeaponBase  weapon;

    [SerializeField] protected List<Character> targetList;

    [SerializeField] protected Character currentTarget;

    [SerializeField]private float timerCoolDown = 0f;

    [SerializeField] private bool isAttacking;
    public bool HaveTarget => targetList?.Count > 0;

    public void OnInit()
    {
        isAttacking = false;
        timerCoolDown = 0f;
        targetList = new List<Character>(); 
        weapon.OnInit();
    }

    public Character GetNearestTarget()
    {
        float smallestDis = 10000000000f;
        Character result = null;
        foreach(Character target in targetList)
        {
            float dis = (character.TF.position - target.TF.position).sqrMagnitude;
            if(dis < smallestDis)
            {
                result = target;
                smallestDis = (character.TF.position - target.TF.position).sqrMagnitude;
            }
        }
        return result;
    }

    public bool CanAttack()
    {
        return timerCoolDown +0.0001f >= weapon.CaculateCoolDown(character.GetStat().GetAtkSpd()) && character.IsStop() && !isAttacking;
    }

    public bool IsTargetValid(Character target)
    {
        
        return target != null && 
        character.CaculateSquaredDistance(target.TF) <= character.GetStat().GetRangeAtk()*character.GetStat().GetRangeAtk()  + 5f
        && !target.GetStat().IsDead && target != character;
    }

    public void AddTarget(Character character)
    {
        if(!targetList.Contains(character)){
            targetList?.Add(character);
        }
    }

    public void RemoveTarget(Character character)
    {
        targetList?.Remove(character);
    }

    public void FilterAllTarget()
    {
        for(int i = targetList.Count - 1; i >= 0; i--)
        {
            if (!IsTargetValid(targetList[i]))
            {
                targetList.RemoveAt(i);
            }
        }
    }
    public void ResetCooldown()
    {
        timerCoolDown = 0f;
    }


    public void Attack()
    {
        if (CanAttack())
        {
            
            if(IsTargetValid(GetNearestTarget())){
                currentTarget =GetNearestTarget();
                isAttacking = true;
                character.SetTargetRotation(character.CaculateDir(currentTarget.TF));
                character.ChangeAnim(GameConfig.ANIM_ATTACK);
            }
            
        }
    }

    public void StartAttack()
    {
        if (CheckCurrentTargetValid())
        {
            weapon.SetActiveVisual(false);
            weapon.StartAttack(character.CaculateDir(currentTarget.TF));
        }
    }

    
    public void EndAttack()
    {
        weapon.SetActiveVisual(true);
        ResetCooldown();
        currentTarget = null;
        isAttacking = false;
    }

    public bool CheckCurrentTargetValid()
    {
        return currentTarget == null || currentTarget == GetNearestTarget();
    }
    public bool IsAttacking()
    {
        return isAttacking;
    }

    void Update()
    {
        FilterAllTarget();
        // if (CheckCurrentTargetValid())
        // {
        //     CancelAttack();
        // }
        timerCoolDown += Time.deltaTime;
    }

}
