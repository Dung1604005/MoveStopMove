using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] protected Character character;
    [SerializeField] protected WeaponBase  weapon;

    [SerializeField] protected List<Character> targetList;

    public void OnInit()
    {
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

    public bool IsTargetValid(Character target)
    {
        return character.CaculateSquaredDistance(target.TF) + 0.001f <= character.GetStat().GetRangeAtk();
    }

    public void AddTarget(Character character)
    {
        targetList?.Add(character);
    }

    public void RemoveTarget(Character character)
    {
        targetList?.Remove(character);
    }


    public void Attack()
    {
        if (!character.IsStop())
        {
            Character target = GetNearestTarget();
            if(IsTargetValid(target)){
                weapon.StartAttack();
            }
        }
    }
}
