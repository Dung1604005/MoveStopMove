
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISkinSlot : MonoBehaviour
{
    [SerializeField] private int skinId;

    [SerializeField] private Image skinPortrait;

    [SerializeField] private GameObject selectedEffect;


    public void SetUpInfo(WeaponSkinData weaponSkinData)
    {
        skinId = weaponSkinData.SkinId;
        SetSkinPortrait(weaponSkinData.GetSpriteUI());
    }

    public void SetSkinPortrait(Sprite _sprite)
    {
        skinPortrait.sprite= _sprite;
    }

    public void SetActiveSelectedEffect(bool active)
    {
        selectedEffect.SetActive(active);
    }


    public void OnPointerClick(BaseEventData baseEventData)
    {
        UIManager.Instance.GetUI<CanvasWeapon>().SetCurrentSkinEquiped(skinId);
    }

}
