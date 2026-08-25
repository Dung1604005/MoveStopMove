using UnityEngine;

public class ObstacleVisble : MonoBehaviour
{
    [SerializeField] private Material baseMat;

    [SerializeField] private Renderer renderer;

    public void TurnInvisble()
    {
        renderer.material = DataManager.Instance.FadeMat;
    }
    public void TurnVisble()
    {
        renderer.material = baseMat;
    }
}
