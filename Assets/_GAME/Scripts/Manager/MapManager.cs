using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private BoosterManager boosterManager;

    [SerializeField] private int maxTry;
    [SerializeField] private float sampleMaxDistance;

    [SerializeField] private Player player;


    public BoosterManager BoosterManager => boosterManager;

    public void OnInit()
    {
        boosterManager.OnInit();
        
    }

    public Vector3 GetPlayerPosition()
    {
        return player.TF.position;
    }

   public bool GetRandomNavMeshPoint(Vector3 center, float radius, out Vector3 result)
    {
        for (int i = 0; i < maxTry; i++)
        {
            Vector2 randomCircle = Random.insideUnitSphere * radius;
            Vector3 randomPoint = center + new Vector3(randomCircle.x, 0f, randomCircle.y);
            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, sampleMaxDistance, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;
        return false;
    }

    void Start()
    {
        OnInit();
    }


}
