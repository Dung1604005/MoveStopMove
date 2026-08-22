using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoosterManager : MonoBehaviour
{
   [SerializeField] private MapManager mapManager;
   [SerializeField] private int maxBooster;

   [SerializeField] private float spawnRad;

   [SerializeField] private List<Transform> spawnCenterList;
   [SerializeField] private BoosterPrefabData boosterPrefabData;
   [SerializeField] private List<BoosterBase> listBooster;


   public void OnInit()
    {
        ClearAllBooster();
        InitAllBooster();
    }

    public BoosterBase GetNearestBooster(Vector3 position)
    {
        float minDis = 10000000000f;

        BoosterBase result = null;
        for(int i = 0; i < listBooster.Count; i++)
        {
            if(listBooster[i] == null)
            {
                Debug.Log("BOOSTER " + i + "IS NULL");
            }
            if((listBooster[i].TF.position - position).sqrMagnitude <= minDis)
            {
                result = listBooster[i];
                minDis = (listBooster[i].TF.position - position).sqrMagnitude;
            }
        }
        return result;
    }

    public Transform GetRandomSpawnCenter()
    {
        int randomVal = Random.Range(0, spawnCenterList.Count);
        return spawnCenterList[randomVal];
    }

    public void SpawnBooster()
    {
        
        if (mapManager.GetRandomNavMeshPoint(GetRandomSpawnCenter().position, 0f,spawnRad,  out Vector3 spawnPosition))
        {
            spawnPosition.y += 1.2f;

            BoosterBase booster = SimplePool.Spawn<BoosterBase>(boosterPrefabData.GetRandomBooster().PoolType, spawnPosition, Quaternion.identity);
            listBooster.Add(booster);
        }
    }

    public void DespawnBooster(BoosterBase booster)
    {

        SimplePool.Despawn(booster);
    }

    public void InitAllBooster()
    {
        for(int i = 0;i < maxBooster; i++)
        {
            SpawnBooster();
        }
    }

    public void ClearAllBooster()
    {
        for(int i = listBooster.Count - 1; i >= 0; i--)
        {
            DespawnBooster(listBooster[i]);
        }
    }
}
