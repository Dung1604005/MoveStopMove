using UnityEngine;
using UnityEngine.UIElements;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private BoosterManager boosterManager;

    [SerializeField] private Player player;


    public BoosterManager BoosterManager => boosterManager;

    public Vector3 GetPlayerPosition()
    {
        return player.TF.position;
    }
}
