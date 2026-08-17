using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinDatabase", menuName = "Scriptable Objects/SkinDatabase")]
public class SkinDatabase : ScriptableObject
{
    [SerializeField] private List<SkinDataSO> listSkinData = new List<SkinDataSO>();


    public SkinDataSO GetSkinData(int skinId)
    {
        return listSkinData[skinId];
    }

    
}
