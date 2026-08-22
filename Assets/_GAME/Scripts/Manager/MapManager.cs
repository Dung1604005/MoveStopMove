using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MapManager : Singleton<MapManager>
{

    [SerializeField] private BoosterManager boosterManager;
    [SerializeField] private int maxTry;
    [SerializeField] private float sampleMaxDistance;

    [SerializeField] private NavMeshSurface navMeshSurface;

    public void OnInit()
    {
        boosterManager.OnInit();


    }
    public BoosterManager GetBoosterManager()
    {
        return boosterManager;
    }

    public void BakeNavmesh(NavMeshData navMeshData)
    {
        navMeshSurface.navMeshData = navMeshData;
        navMeshSurface.AddData();
    }

    public bool GetRandomNavMeshPoint(Vector3 center, float minRadius, float radius, out Vector3 result)
    {
        float minRadiusSqr = minRadius * minRadius;
        float maxRadiusSqr = radius * radius;
        float radiusDiffSqr = maxRadiusSqr - minRadiusSqr;

        for (int i = 0; i < maxTry; i++)
        {
            Vector2 unitCircle = Random.insideUnitCircle;

            Vector2 dir2D = unitCircle.normalized;

            float dist = Mathf.Sqrt(minRadiusSqr + Random.value * radiusDiffSqr);

            Vector3 randomPoint = new Vector3(center.x + dir2D.x * dist, center.y, center.z + dir2D.y * dist);
            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, sampleMaxDistance, NavMesh.AllAreas))
            {
                float dx = hit.position.x - center.x;
                float dz = hit.position.z - center.z;
                float sqrDist = dx * dx + dz * dz;

                if (sqrDist >= minRadiusSqr && sqrDist <= maxRadiusSqr)
                {
                    result = hit.position;
                    return true;
                }
            }
        }

        result = Vector3.zero;
        return false;
    }
}
