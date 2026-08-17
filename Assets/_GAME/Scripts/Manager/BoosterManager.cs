using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoosterManager : MonoBehaviour
{
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
}
