using UnityEngine;

public class CanvasMainMenu : UICanvas
{
   
   public void OnButtonWeapon()
    {
        UIManager.Instance.OpenUI<CanvasWeapon>();
    }
}
