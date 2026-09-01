using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private CameraFollow mainCameraFollow;

    [SerializeField] private CameraFollow uiCameraFollow;

    [SerializeField] private ModelShowcase modelShowcase;

    [SerializeField] private GameState currentGameState;
    public CameraFollow GetMainCameraFollow()
    {
        return mainCameraFollow;
    }
    public CameraFollow GetUICameraFollow()
    {
        return uiCameraFollow;
    }
    public ModelShowcase GetModelShowcase()
    {
        return modelShowcase;
    }

    public void SetCurrentGameState(GameState gameState)
    {
        currentGameState = gameState;
    }

    public GameState GetCurrentGameState()
    {
        return currentGameState;
    }

    void Awake()
    {
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
}


public enum GameState
{
    MAINMENU,
    PLAYING,
    PAUSED
}