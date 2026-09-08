using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private MapData mapData;

    [SerializeField] private int totalCharacter;

    [SerializeField] private int goldPerRank;

    [SerializeField] private Sprite spriteUIMap;

    public MapData MapData => mapData;

    public int TotalCharacter => totalCharacter;

    public int GoldPerRank => goldPerRank;
}
