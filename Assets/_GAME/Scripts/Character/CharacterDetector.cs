using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class CharacterDetector : MonoBehaviour
{
    [SerializeField] private Transform tf;
    [SerializeField] private Character character;

    [SerializeField] private Transform inTargetStateTF;

    [SerializeField] private DecalProjector decalProjector;

    [SerializeField] private bool isInTargetState;

    [SerializeField] private float intervalTime;

    [SerializeField] private List<ObstacleVisble> listObstacle = new List<ObstacleVisble>();

    private LayerMask layerCharacter;

    private LayerMask layerObstacle;

    private float timer = 0f;


    public void OnInit()
    {
        layerCharacter = LayerMask.GetMask(GameConfig.CHARACTER_LAYER);
        layerObstacle = LayerMask.GetMask(GameConfig.OBSTACLe_LAYER);
        listObstacle = new List<ObstacleVisble>();
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
        if(character.IsPlayer) ClearAllObstacle();
    }

    public void SetActiveInTargetState(bool active)
    {
        inTargetStateTF.gameObject.SetActive(active);
        isInTargetState = active;
    }
    public void ScanTargetCharacter()
    {
        Collider[] charColArr = Physics.OverlapSphere(tf.position, character.GetStat().RangeAtk, layerCharacter);

        for(int i = 0; i < charColArr.Length; i++)
        {
            Character target = ColliderCache<Character>.GetComponent(charColArr[i]);

            if (character.GetCombat().IsTargetValid(target))
            {
                character.GetCombat().AddTarget(target);
            }
        }
    }
    public void ScanTargetObstacle()
    {
        ClearAllObstacle();
        Collider[] obstacleColArr = Physics.OverlapSphere(tf.position, character.GetStat().RangeAtk, layerObstacle);

        for(int i = 0; i < obstacleColArr.Length; i++)
        {
            ObstacleVisble obstacleVisble = ColliderCache<ObstacleVisble>.GetComponent(obstacleColArr[i]);
            
            AddObstacle(obstacleVisble);
            
        }
    }
    public void AddObstacle(ObstacleVisble obstacleVisble)
    {
        if (obstacleVisble == null || listObstacle.Contains(obstacleVisble)) return;
        obstacleVisble.TurnInvisble();
        listObstacle.Add(obstacleVisble);
    }

    public void RemoveObstacle(ObstacleVisble obstacleVisble)
    {
        obstacleVisble.TurnVisble();
        listObstacle.Remove(obstacleVisble);
    }
    public bool IsObstacleInRange(Transform tf)
    {
        return  character.CaculateSquaredDistance(tf) <= character.GetStat().RangeAtk * character.GetStat().RangeAtk + 5f;
    }
    public void ClearAllObstacle()
    {
        for(int i = 0 ; i < listObstacle.Count; i++)
        {
            listObstacle[i].TurnVisble();
        }
        listObstacle.Clear();
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= intervalTime)
        {
            timer = 0f;
            ScanTargetCharacter();
            if (character.IsPlayer)
            {
                ScanTargetObstacle();
            
            }
        }
        
    }
}
