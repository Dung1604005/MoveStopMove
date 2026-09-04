using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinDatabase", menuName = "Scriptable Objects/SkinDatabase")]
public class SkinDatabase : ScriptableObject
{
    [SerializeField] private SkinType skinType;

    [SerializeField] private List<SkinDataSO> listSkin = new List<SkinDataSO>();

    public SkinType GetSkinType()
    {
        return skinType;
    }

     public SkinDataSO GetSkinData(int skinId) 
    {
        
        return listSkin[skinId];
    }

    public  int GetRandomSkin() 
    {
        int randomHat = UnityEngine.Random.Range(0, listSkin.Count);
        return randomHat;
    }

    public int GetTotalNumberSkin()
    {
        return listSkin.Count;
    } 
}
