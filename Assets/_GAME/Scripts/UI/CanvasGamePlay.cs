using TMPro;
using UnityEngine;

public class CanvasGamePlay : UICanvas
{
    [SerializeField] private TextMeshProUGUI aliveTxt;

    [SerializeField] private Transform tf;

    public Transform TF => tf == null ? tf = transform : tf; 


    public void SetAliveText(int alive)
    {
        aliveTxt.text = alive.ToString();
    }
}
