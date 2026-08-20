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

    public HatType GetRandomHat()
    {
        int randomVal = Random.Range(0, listHatdata.Count-1);
        return listHatdata[randomVal].HatType;
    }
}
