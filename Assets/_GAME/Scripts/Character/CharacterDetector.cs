using UnityEngine;

public class CharacterDetector : MonoBehaviour
{
    [SerializeField] private Transform tf;
    [SerializeField] private CharacterCombat combat;

    [SerializeField] private CharacterStat stat;


    public void OnInit()
    {
        tf.localScale = Vector3.one*stat.GetRangeAtk();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(GameConfig.CHARACTER_TAG))
        {
            Character target = ColliderCache<Character>.GetComponent(collider);
            if (combat.IsTargetValid(target))
            {
                combat.AddTarget(target);
            }
        }
       
    }
}
