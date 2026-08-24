using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private MapManager mapManager;

    [SerializeField] private EnemyManager enemyManager;

    [SerializeField] private Player player;

    [SerializeField]private int currentAlive;

    public int CurrentAlive => currentAlive;

    public Vector3 GetPlayerPosition()
    {
        return player.TF.position;
    }
    
    public MapManager GetMapManager()
    {
        return mapManager;
    }

    public EnemyManager GetEnemyManager()
    {
        return enemyManager;
    }
    public void LoadLevelData(LevelData levelData)
    {
        this.levelData = levelData;
        LoadMap(levelData.MapData);
    }
    
    public void LoadMap(MapData mapData)
    {
        if(mapManager != null && mapManager.gameObject != null)
        {
            Destroy(mapManager.gameObject);
        }
        mapManager = Instantiate(mapData.PrefabMap, mapData.SpawnPos, Quaternion.identity);
    }

    public void SetCurrentAlive(int _currentAlive)
    {
        currentAlive = _currentAlive;
    }
   public void OnInit()
    {
        LoadLevelData(levelData);
        SetCurrentAlive(levelData.TotalCharacter);
        mapManager.OnInit();
        player.OnInit();
        enemyManager.OnInit();
    }

    void Awake()
    {
        OnInit();
    }
}
