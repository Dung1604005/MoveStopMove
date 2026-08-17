using UnityEngine;

[CreateAssetMenu(fileName = "PantSkinDataSO", menuName = "Scriptable Objects/PantSkinDataSO")]
public class PantSkinDataSO : SkinDataSO
{
    [SerializeField] private PantType pantType; 


    public PantType PantType => pantType;

    public override void ChangeVisualSkin(Character character)
    {
        character.ChangePant(pantType);
    }

    public override void RemoveVisualSkin(Character character)
    {
        base.RemoveVisualSkin(character);
        character.ChangePant(PantType.NONE);
    }
}
