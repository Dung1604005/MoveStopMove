using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoosterManager : MonoBehaviour
{
   [SerializeField] private int maxBooster;

   [SerializeField] private float spawnRad;

   [SerializeField] private List<Transform> spawnCenterList;
   [SerializeField] private BoosterPrefabData boosterPrefabData;
   [SerializeField] private List<BoosterBase> listBooster;


   public void OnInit()
    {
        listBooster = new List<BoosterBase>();
    }

    public BoosterBase GetNearestBooster(Vector3 position)
    {
        float minDis = 10000000000f;

        BoosterBase result = null;
        for(int i = 0; i < listBooster.Count; i++)
        {
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
        if (MapManager.Instance.GetRandomNavMeshPoint(GetRandomSpawnCenter().position, spawnRad,  out Vector3 spawnPosition))
        {
            spawnPosition.y += 1.2f;

            BoosterBase booster = SimplePool.Spawn<BoosterBase>(boosterPrefabData.GetRandomBooster().PoolType, spawnPosition, Quaternion.identity);

        }
    }

    public void DespawnBooster(BoosterBase booster)
    {

        SimplePool.Despawn(booster);
    }
}
