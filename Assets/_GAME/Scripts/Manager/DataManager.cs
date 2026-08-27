using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private ColorDataSO colorDataSO;
    [SerializeField] private SkinDatabase skinDatabase;

    [SerializeField] private Material fadeMat;

    [SerializeField] private WeaponDatabase weaponDatabase;

    [SerializeField] private PlayerDataController playerDataController;

    public Material FadeMat => fadeMat;
    public SkinDatabase SkinDatabase => skinDatabase;

    public ColorDataSO ColorDataSO => colorDataSO;

    public WeaponDatabase WeaponDatabase =>weaponDatabase;
}
