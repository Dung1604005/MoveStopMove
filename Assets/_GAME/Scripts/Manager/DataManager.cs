using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private PantSkinDatabase pantSkinDatabase;

    [SerializeField] private HatSkinDatabase hatSkinDatabase;

    public PantSkinDatabase PantSkinDatabase => pantSkinDatabase;

    public HatSkinDatabase HatSkinDatabase => hatSkinDatabase;
}
