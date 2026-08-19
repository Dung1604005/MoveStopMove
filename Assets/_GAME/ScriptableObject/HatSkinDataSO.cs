using UnityEngine;

[CreateAssetMenu(fileName = "HatSkinDataSO", menuName = "Scriptable Objects/HatSkinDataSO")]
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
    HORN = 0,
    HEADPHONE = 1,

    HAT_CAP = 2,
    NONE = 3

}