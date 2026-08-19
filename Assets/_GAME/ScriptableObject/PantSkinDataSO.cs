using UnityEngine;

[CreateAssetMenu(fileName = "PantSkinDataSO", menuName = "Scriptable Objects/PantSkinDataSO")]
public class PantSkinDataSO : SkinDataSO
{
    [SerializeField] private PantType pantType; 

    [SerializeField] private Material pantMat;


    public PantType PantType => pantType;

    public Material GetPantMat()
    {
        return pantMat;
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