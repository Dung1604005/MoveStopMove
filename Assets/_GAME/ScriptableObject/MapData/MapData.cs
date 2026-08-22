
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "MapData", menuName = "Scriptable Objects/MapData")]
public class MapData : ScriptableObject
{
    [SerializeField] public MapManager PrefabMap;

    [SerializeField] public Vector3 SpawnPos;

    [SerializeField] public NavMeshData NavMeshData;
}
