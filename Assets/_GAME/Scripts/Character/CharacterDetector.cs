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

    [SerializeField] private float intervalTime;

    private LayerMask layerCharacter;

    private LayerMask layerObstacle;

    private float timer = 0f;


    public void OnInit()
    {
        layerCharacter = LayerMask.GetMask(GameConfig.CHARACTER_LAYER);
        layerObstacle = LayerMask.GetMask(GameConfig.OBSTACLe_LAYER);
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
    public void ScanTargetCharacter()
    {
        Collider[] charColArr = Physics.OverlapSphere(tf.position, stat.RangeAtk, layerCharacter);

        for(int i = 0; i < charColArr.Length; i++)
        {
            Character target = ColliderCache<Character>.GetComponent(charColArr[i]);

            if (combat.IsTargetValid(target))
            {
                combat.AddTarget(target);
            }
        }
    }
    public void ScanTargetObstacle()
    {
        Collider[] obstacleColArr = Physics.OverlapSphere(tf.position, stat.RangeAtk, layerObstacle);

        for(int i = 0; i < obstacleColArr.Length; i++)
        {
            ObstacleVisble obstacleVisble = ColliderCache<ObstacleVisble>.GetComponent(obstacleColArr[i]);
            obstacleVisble.TurnInvisble();
        }
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= intervalTime)
        {
            timer = 0f;
            ScanTargetCharacter();
        }
    }
}
