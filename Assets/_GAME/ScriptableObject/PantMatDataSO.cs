using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PantMatDataSO", menuName = "Scriptable Objects/PantMatDataSO")]
public class PantMatDataSO : ScriptableObject
{
    [SerializeField] private List<Material> listPantMat = new List<Material>();

    public Material GetPantMat(PantType pantType)
    {
        return listPantMat[(int)pantType];
    }

    public Material GetRandomMat(PantType pantType)
    {
        int randomVal = Random.Range(0, listPantMat.Count);
        return listPantMat[randomVal];
    }
}

public enum PantType
{
    BATMAN = 0,
    CHAMBI = 1,
    COMI = 2,
    DABAO = 3,
    SKULL = 4,
    VANTIM = 5,
    NONE = 6
}
