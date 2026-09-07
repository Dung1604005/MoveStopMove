using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSkinData", menuName = "Scriptable Objects/Weapon/WeaponSkinData")]
public class WeaponSkinData : ScriptableObject
{
    [SerializeField] private int skinId;
    [SerializeField] private Material skinMat;

    [SerializeField] private Sprite spriteUI;

    [SerializeField] private int price;

    public Material GetSkinMat() {return skinMat;}

    public Sprite GetSpriteUI() {return spriteUI;}

    public int SkinId => skinId;

    public int Price => price;
}
