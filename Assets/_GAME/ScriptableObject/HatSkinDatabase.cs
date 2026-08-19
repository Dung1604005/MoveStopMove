using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HatSkinDatabase", menuName = "Scriptable Objects/HatSkinDatabase")]
public class HatSkinDatabase : ScriptableObject
{
     [SerializeField] private List<HatSkinDataSO> listHatdata = new List<HatSkinDataSO>();

    public HatSkinDataSO GetHatData(HatType hatType)
    {
        return listHatdata[(int)hatType];
    }

    public HatSkinDataSO GetRandomHat(HatType hatType)
    {
        int randomVal = Random.Range(0, listHatdata.Count);
        return listHatdata[randomVal];
    }
}
