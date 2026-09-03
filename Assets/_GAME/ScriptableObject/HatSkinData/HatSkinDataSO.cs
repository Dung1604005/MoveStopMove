using UnityEngine;

[CreateAssetMenu(fileName = "HatSkinDataSO", menuName = "Scriptable Objects/Hat/HatSkinDataSO")]
public class HatSkinDataSO : SkinDataSO
{
    [SerializeField] private Vector3 spawnPos;

    [SerializeField] private GameUnit hatPrefab;

    [SerializeField] private HatType hatType;



    public Vector3 SpawnPos => spawnPos;

    public GameUnit HatPrefab => hatPrefab;

    public HatType HatType => hatType;
}


public enum HatType
{
    HORN = 1,
    HEADPHONE = 2,

    HAT_CAP = 3,
    NONE = 0

}