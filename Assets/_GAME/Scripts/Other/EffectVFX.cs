using UnityEngine;

public class EffectVFX : MonoBehaviour
{
    [SerializeField] private Transform tf;

    [SerializeField] private float effectTime;


    private float timer = 0f;

    public void SetActive(bool active)
    {
        tf.gameObject.SetActive(active);
    }
    public void SetPosition(Vector3 position)
    {
        tf.position = position;
    }

    public void OnInit()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= effectTime)
        {
            SetActive(false);
        }
    }
}
