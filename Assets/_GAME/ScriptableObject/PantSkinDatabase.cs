using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PantSkinDatabase", menuName = "Scriptable Objects/PantSkinDatabase")]
public class PantSkinDatabase : ScriptableObject
{
    
    [SerializeField] private List<PantSkinDataSO> listPantdata = new List<PantSkinDataSO>();

    public PantSkinDataSO GetPantData(PantType pantType)
    {
        return listPantdata[(int)pantType];
    }

    public PantSkinDataSO GetRandomPant(PantType pantType)
    {
        int randomVal = Random.Range(0, listPantdata.Count);
        return listPantdata[randomVal];
    }
}
