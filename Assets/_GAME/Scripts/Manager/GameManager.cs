using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private CameraFollow mainCameraFollow;

    [SerializeField] private CameraFollow uiCameraFollow;
    public CameraFollow GetMainCameraFollow()
    {
        return mainCameraFollow;
    }
    public CameraFollow GetUICameraFollow()
    {
        return uiCameraFollow;
    }
}
