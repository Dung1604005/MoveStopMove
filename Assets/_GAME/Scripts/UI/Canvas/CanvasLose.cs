using System.Collections;
using TMPro;
using UnityEngine;

public class CanvasLose : UICanvas
{
    [Header("REVIVE")]

    [SerializeField] private Transform reviveTF;

    [SerializeField] private TextMeshProUGUI countDownTxt;

    [SerializeField] private float timeCount;

    [SerializeField] private float timeElapse;

    [SerializeField] private TextMeshProUGUI reviveCostTxt;

    [Header("LOSE")]

    [SerializeField] private Transform loseTF;

    [SerializeField] private TextMeshProUGUI rankTxt;

    [SerializeField] private TextMeshProUGUI goldRewardTxt;



    public override void SetUp()
    {
        base.SetUp();
        gameObject.SetActive(true);

        SetActiveRevive(true);
        SetActiveLose(false);
    }

    public void SetActiveRevive(bool active)
    {
        reviveTF.gameObject.SetActive(active);
        if (active)
        {
            StartCoroutine(IECountdown(timeCount));
            SetReviveCostTxt(GameConfig.REVIVE_COST);
        }

    }
    public void SetActiveLose(bool active)
    {
        loseTF.gameObject.SetActive(active);

        if (active)
        {
            SetRankTxt(LevelManager.Instance.GetRankPlayer());
            SetGoldReward(LevelManager.Instance.GetGoldReward());
        }
    }

    public void SetCountDownTxt(int _time)
    {
        countDownTxt.text = _time.ToString();
    }
    public void SetReviveCostTxt(int reviveCost)
    {
        reviveCostTxt.text = reviveCost.ToString();
    }

    public void SetRankTxt(int rank)
    {
        rankTxt.text = "#" + rank.ToString();
    }

    public void SetGoldReward(int gold)
    {
        goldRewardTxt.text = gold.ToString();
    }

    private IEnumerator IECountdown(float duration)
    {
        float timer = duration;

        while (timer > 0.01f)
        {
            SetCountDownTxt((int)timer);
            yield return new WaitForSeconds(timeElapse);
            timer -= timeElapse;
        }

        SetActiveRevive(false);
        SetActiveLose(true);
    }

    public void OnReviveButton()
    {
        int price = GameConfig.REVIVE_COST;
        if (DataManager.Instance.PlayerDataController.CanAfford(price))
        {
           
            DataManager.Instance.PlayerDataController.ChangeGold(-price);

            UIManager.Instance.CloseAllDirectly();
            LevelManager.Instance.RevivePlayer();
        }
    }

    public void OnHomeButton()
    {
        UIManager.Instance.CloseAllDirectly();

        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }


}
