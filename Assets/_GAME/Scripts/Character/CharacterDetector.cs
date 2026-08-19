using UnityEngine;
using UnityEngine.Rendering.Universal;
public class CharacterDetector : MonoBehaviour
{
    [SerializeField] private Transform tf;
    [SerializeField] private CharacterCombat combat;

    [SerializeField] private CharacterStat stat;

    [SerializeField] private Transform inTargetStateTF;

    [SerializeField] private DecalProjector decalProjector;

    [SerializeField] private bool isInTargetState;


    public void OnInit()
    {
        
        SetActiveInTargetState(false);
    }

    public void SetSizeRange(float size)
    {
        tf.localScale = Vector3.one*size*2;
        if(decalProjector!= null) decalProjector.size = new Vector3(size*2, size*2, 2f);
    }

    public void OnDespawn()
    {
        SetActiveInTargetState(false);
    }

    public void SetActiveInTargetState(bool active)
    {
        inTargetStateTF.gameObject.SetActive(active);
        isInTargetState = active;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(GameConfig.CHARACTER_TAG))
        {
            Character target = ColliderCache<Character>.GetComponent(collider);

            if(target == null)
            {
                Debug.Log("TARGET NULL");
            }
            if (combat.IsTargetValid(target))
            {
                combat.AddTarget(target);
            }
        }
       
    }

    void Update()
    {
        
    }
}
