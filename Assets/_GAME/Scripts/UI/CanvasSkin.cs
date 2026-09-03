using UnityEngine;

public class CanvasSkin : UICanvas
{
   [SerializeField] private SkinType currentSkinType;

   [SerializeField] private Transform listPantHolder;

   [SerializeField] private Transform listHatHolder;



   public SkinType GetCurrentSkinType() {return currentSkinType;}


    public override void SetUp()
    {
        base.SetUp();
        GameManager.Instance.GetModelShowcase().SetActiveCharacterModel(true);
    }

    public void ClearAllPant()
    {
        
    }
    public void SetUpPantSkins()
    {
        
    }
}
