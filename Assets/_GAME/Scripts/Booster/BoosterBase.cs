using UnityEngine;

public class BoosterBase : GameUnit
{
    [SerializeField] private BoosterType boosterType;

    public void OnInit()
    {
        
    }
    public virtual void ApplyBuff(Character character)
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConfig.CHARACTER_TAG))
        {
            Character character = ColliderCache<Character>.GetComponent(other);

            ApplyBuff(character);

            LevelManager.Instance.GetMapManager().GetBoosterManager().DespawnBooster(this);
            LevelManager.Instance.GetMapManager().GetBoosterManager().SpawnBooster(true);
        }
    }


}

public enum BoosterType
{
    LEVEL_UP = 0,
    HEAL = 1,
    RANGE_BUFF= 2
}
