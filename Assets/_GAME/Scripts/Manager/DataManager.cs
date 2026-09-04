using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private ColorDataSO colorDataSO;
    [SerializeField] private List<SkinDatabase> listSkinDatabase;

    [SerializeField] private Material fadeMat;

    [SerializeField] private WeaponDatabase weaponDatabase;

    [SerializeField] private PlayerDataController playerDataController;

    public Material FadeMat => fadeMat;

    public ColorDataSO ColorDataSO => colorDataSO;

    public WeaponDatabase WeaponDatabase =>weaponDatabase;

    public PlayerDataController PlayerDataController => playerDataController;

    private Dictionary<SkinType, SkinDatabase> dictSkinDatabase;

    public void OnInit()
    {
        dictSkinDatabase = new Dictionary<SkinType, SkinDatabase>();
        foreach(SkinDatabase skinDatabase in listSkinDatabase)
        {
            dictSkinDatabase.Add(skinDatabase.GetSkinType(), skinDatabase);
        }

        playerDataController.LoadData();
    }

    public SkinDatabase GetSkinDatabase(SkinType skinType)
    {
        return dictSkinDatabase[skinType];
    }
}
