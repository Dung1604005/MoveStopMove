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