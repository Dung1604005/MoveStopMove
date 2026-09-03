using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PantDatabase", menuName = "Scriptable Objects/Pant/PantDatabase")]
public class PantDatabase : ScriptableObject
{
    [SerializeField] private List<PantSkinDataSO> listPant = new List<PantSkinDataSO>();


    public PantSkinDataSO GetPantData(PantType pantType) 
    {
        return listPant[(int)pantType];
    }

    public  PantType GetRandomPant() 
    {
        int randomVal = Random.Range(0, listPant.Count);
        return (PantType)randomVal;
    }

    public int GetTotalNumberPant()
    {
        return listPant.Count;
    }
}
public enum PantType
{
     PANT_BATMAN = 1,
    PANT_CHAMBI = 2,
    PANT_COMI = 3,
    PANT_DABAO = 4,
    PANT_SKULL = 5,
    PANT_VANTIM =6,

    PANT_POKEMON = 7,
    PANT_NONE = 0,
}