using TMPro;
using UnityEngine;

public class CanvasLoading : UICanvas
{
    [SerializeField] private float timeLoading;

    private UICanvas canvasParent;

    private float timer = 0f;

    public override void SetUp()
    {
        base.SetUp();
        timer = 0f;
    }

    public override void Open(UICanvas uICanvas)
    {
        base.Open(uICanvas);
        canvasParent = uICanvas;
    }

    public void Despawn()
    {
        UIManager.Instance.CloseUIDirectly<CanvasLoading>();

        if(canvasParent == null)
        {
            UIManager.Instance.OpenUI<CanvasMainMenu>();
            GameManager.Instance.SetCurrentGameState(GameState.MAINMENU);
            GameManager.Instance.OnMainMenu();
        }
        else if(canvasParent is CanvasMainMenu)
        {
            UIManager.Instance.OpenUI<CanvasGamePlay>();
            GameManager.Instance.SetCurrentGameState(GameState.PLAYING);
            GameManager.Instance.OnPlayGame();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeLoading)
        {
            Despawn();
        }
    }


}
