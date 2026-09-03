using UnityEngine;

public class CanvasMainMenu : UICanvas
{
   
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
