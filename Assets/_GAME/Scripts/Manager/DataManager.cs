using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private ColorDataSO colorDataSO;
    [SerializeField] private SkinDatabase skinDatabase;

    [SerializeField] private Material fadeMat;

    public Material FadeMat => fadeMat;
    public SkinDatabase SkinDatabase => skinDatabase;

    public ColorDataSO ColorDataSO => colorDataSO;
}
