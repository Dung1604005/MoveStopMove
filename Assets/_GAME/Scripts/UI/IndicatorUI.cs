using UnityEngine;
using UnityEngine.UI;

public class IndicatorUI : GameUnit
{
    [SerializeField] private Camera uiCamera;
    [SerializeField] private Transform target;
    [SerializeField] private RectTransform rectTF;
    [SerializeField] private float borderSize = 60f;

    [SerializeField] private Image image;

    public void OnInit()
    {
        uiCamera = GameManager.Instance.GetUICameraFollow().GetCam();
    }

    public void OnDespawn()
    {
        target = null;
        SimplePool.Despawn(this);
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
        bool isOffScreen = screenPos.z <= 0 ||
                           screenPos.x <= borderSize ||
                           screenPos.x >= Screen.width - borderSize ||
                           screenPos.y <= borderSize ||
                           screenPos.y >= Screen.height - borderSize;

        if (isOffScreen)
        {
            SetActive(true);

            float angle = Mathf.Atan2(screenDir.y, screenDir.x) * Mathf.Rad2Deg;
            
            rectTF.localEulerAngles = new Vector3(0, 0, angle-90f);

            Vector3 cappedPosition = GetScreenEdgePosition(screenCenter, screenDir.normalized);

            
            rectTF.position = cappedPosition;
            
        }
        else
        {
            SetActive(false);
        }
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
        
        image.enabled = active;
        
    }

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }
}