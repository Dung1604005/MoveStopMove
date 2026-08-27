using UnityEngine;

public class PlayerDataController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;


    public int GetCurrentGold() {return playerData.GoldAmount;}

    public void UpdateGold(int _gold) {playerData.GoldAmount = _gold;}

    public string GetNamePlayer(){return playerData.NamePlayer;}

    public void UpdateNamePlayer(string _name){playerData.NamePlayer = _name;}

}
