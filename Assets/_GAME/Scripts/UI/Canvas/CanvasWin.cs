using TMPro;
using UnityEngine;

public class CanvasWin : UICanvas
{
    [SerializeField] private TextMeshProUGUI goldRewardTxt;



    public void SetGoldRewardText(int _gold)
    {
        goldRewardTxt.text = _gold.ToString();
    }

    public void OnHomeButton()
    {
        UIManager.Instance.CloseAllDirectly();

        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
}
