using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HatDatabase", menuName = "Scriptable Objects/Hat/HatDatabase")]
public class HatDatabase : ScriptableObject
{
    [SerializeField] private List<HatSkinDataSO> listHat = new List<HatSkinDataSO>();


    public HatSkinDataSO GetHatData(HatType hatType) 
    {
        return listHat[(int)hatType];
    }

    public  HatType GetRandomHat() 
    {
        int randomVal = Random.Range(0, listHat.Count);
        return (HatType)randomVal;
    }

    public int GetTotalNumberHat()
    {
        return listHat.Count;
    }
}
