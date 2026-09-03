using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private ColorDataSO colorDataSO;
    [SerializeField] private PantDatabase pantDatabase;
    [SerializeField] private HatDatabase hatDatabase;

    [SerializeField] private Material fadeMat;

    [SerializeField] private WeaponDatabase weaponDatabase;

    [SerializeField] private PlayerDataController playerDataController;

    public Material FadeMat => fadeMat;

    public ColorDataSO ColorDataSO => colorDataSO;

    public WeaponDatabase WeaponDatabase =>weaponDatabase;

    public PantDatabase PantDatabase => pantDatabase;

    public HatDatabase HatDatabase => hatDatabase;
}
