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
    public int GetPlayerLevel()
    {
        return player.GetStat().Level;
    }
    public Player GetPlayer()
    {
        return player;
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
        mapManager = Instantiate(mapData.PrefabMap, mapData.SpawnPos, Quaternion.identity);
    }

    public int GetRankPlayer()
    {
        return currentAlive;
    }

    public void RevivePlayer()
    {
        player.OnRevive();
        UIManager.Instance.OpenUI<CanvasGamePlay>();
    }

    public int GetGoldReward()
    {
        return levelData.GoldPerRank*(levelData.TotalCharacter - currentAlive);
    }

    public void SetCurrentAlive(int _currentAlive)
    {
        currentAlive = _currentAlive;
        UIManager.Instance.GetUI<CanvasGamePlay>().SetAliveText(currentAlive);
    }
   public void OnInit()
    {
        LoadLevelData(levelData);
        SetCurrentAlive(levelData.TotalCharacter);
        mapManager.OnInit();
        player.GetCombat().InitWeapon(DataManager.Instance.WeaponDatabase.GetRandomWeaponPrefab());
        player.OnInit();
        if(LevelManager.Instance.GetMapManager().GetRandomNavMeshPoint(Vector3.zero, 0f, 75f,out Vector3 spawnPos))
        {
           player.SetSpawn(spawnPos);
        }
        enemyManager.OnInit();
    }

    public void OnDespawn()
    {
        player.OnDespawn();
        mapManager.OnDespawn();
        enemyManager.OnDespawn();
        ColliderCache<Character>.ClearAll();
        ColliderCache<ObstacleVisble>.ClearAll();

    }


}
