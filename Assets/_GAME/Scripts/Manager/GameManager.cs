using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private CameraFollow mainCameraFollow;

    [SerializeField] private Camera uiCamera;

    public CameraFollow MainCameraFollow => mainCameraFollow;

    public Camera UICamera => uiCamera;
}
