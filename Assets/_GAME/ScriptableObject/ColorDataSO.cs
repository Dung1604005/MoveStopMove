using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorDataSO", menuName = "Scriptable Objects/ColorDataSO")]
public class ColorDataSO : ScriptableObject
{
    [SerializeField] private List<Material> listColorMat = new List<Material>();

    [SerializeField] private List<Color> listColor = new List<Color>();

    public Material GetColorMat(ColorType colorType)
    {
        return listColorMat[(int)colorType];
    }
    public Color GetColor(ColorType colorType)
    {
        return listColor[(int)colorType];
    }

    public ColorType GetRandomColor()
    {
        int randomColor = Random.Range(0, listColorMat.Count);
        return (ColorType)randomColor;
    }
}

public enum ColorType
{
    BLACK = 0,
    YELLOW = 1,
    RED = 2,
    BLUE,
    GREEN,
    VIOLET,
    ORANGE,
    PINK
}