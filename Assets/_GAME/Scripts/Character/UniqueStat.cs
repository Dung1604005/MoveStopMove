using UnityEngine;

using System;
using System.Collections.Generic;

[Serializable]
public class UniqueStatController
{
    [SerializeField] private List<UniqueStat> uniqueStats = new List<UniqueStat>();
    

    public void OnInit()
    {
        foreach(UniqueStat uniqueStat in uniqueStats)
        {
            DeActiveUniqueStat(uniqueStat.uniqueStatType);
        }
    }

    public void ActiveUniqueStat(UniqueStatType uniqueStatType, float _duration)
    {
        DeActiveUniqueStat(uniqueStatType);
        uniqueStats[(int)uniqueStatType].active = true;
        uniqueStats[(int)uniqueStatType].duration = _duration;
        uniqueStats[(int)uniqueStatType].timer = 0f;
    }
    public void DeActiveUniqueStat(UniqueStatType uniqueStatType)
    {
        uniqueStats[(int)uniqueStatType].active = false;
        uniqueStats[(int)uniqueStatType].timer = 0f;
    }

    public bool IsThisUniqueStatActive(UniqueStatType uniqueStatType)
    {
        return uniqueStats[(int)uniqueStatType].active;
    }

    public void UpdateStateUniqueStat(UniqueStatType uniqueStatType)
    {
        UniqueStat uniqueStat = uniqueStats[(int)uniqueStatType];
        if (uniqueStat.active)
        {
            uniqueStat.timer += Time.deltaTime;
            if(uniqueStat.timer >= uniqueStat.duration)
            {
                DeActiveUniqueStat(uniqueStatType);
            }
        }
    }

    public void Update()
    {
        foreach(UniqueStat uniqueStat in uniqueStats)
        {
            UpdateStateUniqueStat(uniqueStat.uniqueStatType);
        }
    }

    
}
[Serializable]
public class UniqueStat
{
    public UniqueStatType uniqueStatType;

    public bool active;

    public float duration;

    public float timer;
}

public enum UniqueStatType
{
    HAVE_SHIELD = 0,
    DUPLICATE_ATTACK = 1,

    TRANSPARENT_BULLET = 2
}
