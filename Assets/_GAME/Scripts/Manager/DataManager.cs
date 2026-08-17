using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private PantMatDataSO pantMatDataSO;

    public PantMatDataSO PantMatDataSO => pantMatDataSO;
}
