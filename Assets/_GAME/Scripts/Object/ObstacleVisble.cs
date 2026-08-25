using System.Collections.Generic;
using UnityEngine;

public class ObstacleVisble : MonoBehaviour
{
    [SerializeField] private Transform tf;
    [SerializeField] private Material baseMat;

    [SerializeField] private List<Renderer> listRenderer = new List<Renderer>();

    public Transform TF => tf;
    private bool isHide= false;

    public void OnInit()
    {
        isHide = false;
    }
    public void TurnInvisble()
    {
        
        if(isHide)return;

        isHide = true;
        for(int i = 0; i < listRenderer.Count; i++)
        {
            listRenderer[i].material = DataManager.Instance.FadeMat;
        }
    }
    public void TurnVisble()
    {
        isHide = false;
        for(int i = 0; i < listRenderer.Count; i++)
        {
            listRenderer[i].material = baseMat;
        }
    }


}
