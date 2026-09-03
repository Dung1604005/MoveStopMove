using System.Collections.Generic;
using UnityEngine;

public class PlayerDataController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;


    public int GetCurrentGold() {return playerData.GoldAmount;}

    public void UpdateGold(int _gold) {playerData.GoldAmount = _gold;}

    public string GetNamePlayer(){return playerData.NamePlayer;}

    public void UpdateNamePlayer(string _name){playerData.NamePlayer = _name;}

    public PantType GetCurrentPant(){return (PantType)playerData.CurrentPant ;}

    public HatType GetCurrentHat() {return (HatType)playerData.CurrentHat;}

    public List<PantType> GetListUnlockedPant()
    {
        List<PantType> listUnlockedPant = new List<PantType>();

        for(int i = 0 ; i < playerData.ListUnlockedPant.Length; i++)
        {
            listUnlockedPant.Add((PantType)playerData.ListUnlockedPant[i]);
        }

        return listUnlockedPant;
    }

    public List<HatType> GetListUnlockedHat()
    {
        List<HatType> listUnlockedHat = new List<HatType>();

        for(int i = 0 ; i < playerData.ListUnlockedHat.Length; i++)
        {
            listUnlockedHat.Add((HatType)playerData.ListUnlockedHat[i]);
        }

        return listUnlockedHat;
    }



}
