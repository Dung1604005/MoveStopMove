using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorUI : GameUnit
{
    [SerializeField] private Camera uiCamera;
    [SerializeField] private Transform target;
    [SerializeField] private RectTransform rectTF;

    [SerializeField] private RectTransform rectArrowTF;
    [SerializeField] private float borderSize ;

    [SerializeField] private Image imageArrow;

    [SerializeField] private Image imageLevel;

    [SerializeField] private GameObject contentRoot;

    [SerializeField] private TextMeshProUGUI levelTxt;

    public void OnInit()
    {
        uiCamera = GameManager.Instance.GetUICameraFollow().GetCam();
    }

    public void OnDespawn()
    {
        target = null;
        SimplePool.Despawn(this);
    }

    public void SetInfor(int level, ColorType colorType, Transform _target)
    {
        SetLevelTxt(level);
        SetImageArrowColor(DataManager.Instance.ColorDataSO.GetColor(colorType));
        SetImageLevelColor(DataManager.Instance.ColorDataSO.GetColor(colorType));
        SetTarget(_target);
    }
    public void SetLevelTxt(int level)
    {
        levelTxt.text = level.ToString();
    }

    public void SetImageLevelColor(Color color)
    {
        imageLevel.color = color;
    }

    public void SetImageArrowColor(Color color)
    {
        imageArrow.color = color;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
        if (screenPos.z < 0)
        {
            screenPos *= -1f;
        }
        Vector3 screenCenter = new Vector3(Screen.width, Screen.height, 0f) * 0.5f;
        Vector3 screenDir = (screenPos - screenCenter);
        if (IsOffScreen(screenPos))
        {
            SetActive(true);
            float angle = Mathf.Atan2(screenDir.y, screenDir.x) * Mathf.Rad2Deg;
            rectArrowTF.localEulerAngles = new Vector3(0, 0, angle - 90f);
            Vector3 cappedPosition = GetScreenEdgePosition(screenCenter, screenDir.normalized);
            rectTF.position = cappedPosition;
        }
        else
        {
            SetActive(false);
        }
    }
    public bool IsOffScreen(Vector3 screenPos)
    {
        return screenPos.z <= 0 ||
                           screenPos.x <= borderSize ||
                           screenPos.x >= Screen.width - borderSize ||
                           screenPos.y <= borderSize ||
                           screenPos.y >= Screen.height - borderSize;
    }

    private Vector3 GetScreenEdgePosition(Vector3 center, Vector3 dir)
    {
        float halfWidth = center.x - borderSize;
        float halfHeight = center.y - borderSize;

        float scaleX = Mathf.Abs(dir.x) > 0.0001f ? halfWidth / Mathf.Abs(dir.x) : float.MaxValue;
        float scaleY = Mathf.Abs(dir.y) > 0.0001f ? halfHeight / Mathf.Abs(dir.y) : float.MaxValue;

        float minScale = Mathf.Min(scaleX, scaleY);

        return center + dir * minScale;
    }

    public void SetActive(bool active)
    {

        contentRoot.SetActive(active);
    }

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }
}