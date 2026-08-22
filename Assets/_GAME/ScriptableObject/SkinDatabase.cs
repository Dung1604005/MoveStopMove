using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "SkinDatabase", menuName = "Scriptable Objects/SkinDatabase")]
public class SkinDatabase : ScriptableObject
{
    [SerializeField] private List<SkinDataSO> listSkin = new List<SkinDataSO>();

    [SerializeField] private Vector2Int pantIdRange;

    [SerializeField] private Vector2Int hatIdRange;

    public T GetSkinData<T>(DetailSkinType detailSkinType) where T: SkinDataSO
    {
        return listSkin[(int)detailSkinType] as T;
    }

    public  DetailSkinType GetRandomPant() 
    {
        int randomVal = Random.Range(pantIdRange.x, pantIdRange.y);
        return (DetailSkinType)randomVal;
    }
    public  DetailSkinType GetRandomHat() 
    {
        int randomVal = Random.Range(hatIdRange.x, hatIdRange.y);
        return (DetailSkinType)randomVal;
    }
}
public enum DetailSkinType
{
    // PANT
    PANT_BATMAN = 0,
    PANT_CHAMBI = 1,
    PANT_COMI = 2,
    PANT_DABAO = 3,
    PANT_SKULL = 4,
    PANT_VANTIM = 5,
    PANT_NONE = 6,
    //Hat

    HAT_HORN = 7,
    HAT_HEADPHONE = 8,

    HAT_CAP = 9,
    HAT_NONE = 10
}