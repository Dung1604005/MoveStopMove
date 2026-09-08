using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<CameraFollow> listCameraFollow;
    

    [SerializeField] private ModelShowcase modelShowcase;

    [SerializeField] private GameState currentGameState;

    public CameraFollow GetCameraFollow(CameraType cameraType)
    {
        return listCameraFollow[(int)cameraType];
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

    public void OnPlayGame()
    {
        LevelManager.Instance.OnInit();
        foreach(CameraFollow cameraFollow in listCameraFollow)
        {
            cameraFollow.OnStartGame();
        }
    }

    public void OnMainMenu()
    {
        foreach(CameraFollow cameraFollow in listCameraFollow)
        {
            cameraFollow.OnMainMenu();
        }
    }
    public void OnInit()
    {
        DataManager.Instance.OnInit();
        UIManager.Instance.OpenUI<CanvasLoading>();
    }

    void Awake()
    {
        OnInit();
    }
}


public enum GameState
{
    MAINMENU,
    PLAYING,
    PAUSED
}