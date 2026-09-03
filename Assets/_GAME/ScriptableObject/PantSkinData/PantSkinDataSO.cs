using UnityEngine;

[CreateAssetMenu(fileName = "PantSkinDataSO", menuName = "Scriptable Objects/Pant/PantSkinDataSO")]
public class PantSkinDataSO : SkinDataSO
{
    [SerializeField] private PantType pantType; 

    [SerializeField] private Material pantMat;

    [SerializeField] private Sprite skinPortrait;

    public Material GetPantMat()
    {
        return pantMat;
    }

    public Sprite GetSprite()
    {
        return skinPortrait;
    }
}