using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoosterPrefabData", menuName = "Scriptable Objects/BoosterPrefabData")]
public class BoosterPrefabData : ScriptableObject
{
    [SerializeField] private List<BoosterBase> boosterList = new List<BoosterBase>();


    public BoosterBase GetBooster(BoosterType boosterType)
    {
        return boosterList[(int)boosterType];
    }

    public BoosterBase GetRandomBooster()
    {
        int randomVal = Random.Range(0, boosterList.Count);

        return boosterList[randomVal];
    }
}
