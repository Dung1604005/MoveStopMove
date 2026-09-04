using UnityEngine;

[CreateAssetMenu(fileName = "PantSkinDataSO", menuName = "Scriptable Objects/Pant/PantSkinDataSO")]
public class PantSkinDataSO : SkinDataSO
{
    [SerializeField] private PantType pantType; 

    [SerializeField] private Material pantMat;

    public Material GetPantMat()
    {
        return pantMat;
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