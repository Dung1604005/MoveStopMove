using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private SkinDatabase skinDatabase;


    public SkinDatabase SkinDatabase => skinDatabase;
}
