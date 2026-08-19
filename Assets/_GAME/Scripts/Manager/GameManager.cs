using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private CameraFollow mainCameraFollow;

    public CameraFollow MainCameraFollow => mainCameraFollow;
}
