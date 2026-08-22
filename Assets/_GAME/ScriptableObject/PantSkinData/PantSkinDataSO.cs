using UnityEngine;

[CreateAssetMenu(fileName = "PantSkinDataSO", menuName = "Scriptable Objects/PantSkinDataSO")]
public class PantSkinDataSO : SkinDataSO
{
    [SerializeField] private DetailSkinType pantType; 

    [SerializeField] private Material pantMat;

    public Material GetPantMat()
    {
        return pantMat;
    }
}