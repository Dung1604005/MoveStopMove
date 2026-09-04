using TMPro;
using UnityEngine;

public class CanvasMainMenu : UICanvas
{
   [SerializeField] private TextMeshProUGUI goldText;

    public override void SetUp()
    {
        base.SetUp();
        SetGoldText(DataManager.Instance.PlayerDataController.GetCurrentGold());
    }

   public void SetGoldText(int gold)
    {
        goldText.text = gold.ToString();
    }
   public void OnButtonWeapon()
    {
        UIManager.Instance.OpenUI<CanvasWeapon>();
    }

    public void OnButtonSkin()
    {
        UIManager.Instance.CloseUIDirectly<CanvasMainMenu>();

        UIManager.Instance.OpenUI<CanvasSkin>();
    }
}
