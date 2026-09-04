
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISkinSlot : MonoBehaviour
{
    [SerializeField] private int skinId;

    [SerializeField] private Image skinPortrait;

    [SerializeField] private GameObject selectedEffect;

    [SerializeField] private GameObject lockedEffect;

    [SerializeField] private UICanvas parentCanvas;

    public void SetParentCanvas(UICanvas uICanvas)
    {
        parentCanvas = uICanvas;
    }
    public void SetUpInfo(int _skinId, Sprite spriteUI)
    {
        skinId = _skinId;
        SetSkinPortrait(spriteUI);
    }

    public void SetSkinPortrait(Sprite _sprite)
    {
        skinPortrait.sprite= _sprite;
    }

    public void SetActiveSelectedEffect(bool active)
    {
        selectedEffect.SetActive(active);
    }

    public void SetActiveLockedEffect(bool active)
    {
        lockedEffect.SetActive(active);
    }

    public void Reload(SkinType skinType)
    {
        SetActiveLockedEffect(!DataManager.Instance.PlayerDataController.IsThisSkinUnlocked(skinType, skinId));

        SetActiveSelectedEffect(DataManager.Instance.PlayerDataController.IsThisSkinIdChoosed(skinType, skinId));
    }


    public void OnPointerClick(BaseEventData baseEventData)
    {
        if(parentCanvas is CanvasWeapon)
        {
            UIManager.Instance.GetUI<CanvasWeapon>().SetCurrentSkinEquiped(skinId);
        }
        else if(parentCanvas is CanvasSkin)
        {
            UIManager.Instance.GetUI<CanvasSkin>().SetCurrentSkin(skinId);
        }
    }

}
