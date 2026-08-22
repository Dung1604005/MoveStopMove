using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private MapData mapData;

    [SerializeField] private int totalCharacter;

    public MapData MapData => mapData;

    public int TotalCharacter => totalCharacter;
}
