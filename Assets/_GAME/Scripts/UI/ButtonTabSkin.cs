
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTabSkin : MonoBehaviour
{
    [SerializeField] private Image imageButton;

    [SerializeField] private TextMeshProUGUI buttonText;

    [SerializeField] private Sprite selectedSprite;

    [SerializeField] private Sprite unSelectedSprite;

    [SerializeField] private Color selectedColorTxt;

    [SerializeField] private Color unSelectedColorTxt;

    public void SetActiveButton(bool active)
    {
        if (active)
        {
            SetSelected();
        }
        else
        {
            SetUnSelected();
        }
    }
    public void SetSelected()
    {
        imageButton.sprite = selectedSprite;
        buttonText.color = selectedColorTxt;
    }

    public void SetUnSelected()
    {
        imageButton.sprite = unSelectedSprite;

        buttonText.color = unSelectedColorTxt;
    }
}
