using UnityEngine;

public class CharacterDetector : MonoBehaviour
{
    [SerializeField] private CharacterCombat combat;

    public void OnTriggerEnter(Collider collider)
    {
        Character target = ColliderCache<Character>.GetComponent(collider);
        if(target!= null)
        {
            combat.AddTarget(target);
        }
    }
}
