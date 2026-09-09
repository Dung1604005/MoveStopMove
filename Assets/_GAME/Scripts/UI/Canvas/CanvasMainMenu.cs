using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMainMenu : UICanvas
{
    [SerializeField] private TextMeshProUGUI goldText;

    [SerializeField] private TMP_InputField nameField;

    public override void SetUp()
    {
        base.SetUp();
        SetGoldText(DataManager.Instance.PlayerDataController.GetCurrentGold());
        SetNameInputField(DataManager.Instance.PlayerDataController.GetNamePlayer());
    }

    public void SetGoldText(int gold)
    {
        goldText.text = gold.ToString();
    }

    public void OnChangeNameText()
    {
        string nameText = nameField.text;  
        DataManager.Instance.PlayerDataController.UpdateNamePlayer(nameText);      

    }

    public void SetNameInputField(string _name)
    {
        nameField.text = _name;
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

    public void OnButtonPlayNormalMode()
    {
        UIManager.Instance.CloseUIDirectly<CanvasMainMenu>();
        UIManager.Instance.OpenUI<CanvasLoading>(this);
    }
}
