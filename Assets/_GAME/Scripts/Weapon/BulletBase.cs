using UnityEngine;

public class BulletBase : GameUnit
{
    [SerializeField] private Vector3 moveDir;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float damage;

    [SerializeField] private float liveTime;

    [SerializeField] private float timerLive;
    
    public void LoadData(Vector3 _moveDir, float _moveSpeed, float _damage)
    {
        moveDir = _moveDir;
        moveSpeed = _moveSpeed;
        damage = _damage;
        timerLive = 0f;

        tf.rotation = Quaternion.LookRotation(moveDir);
    }

    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    public void Move()
    {
       
        tf.position = Vector3.MoveTowards(tf.position, tf.position + moveDir, moveSpeed*Time.fixedDeltaTime);
        
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        timerLive += Time.deltaTime;
        if(timerLive >= liveTime)
        {
            OnDespawn();
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(GameConfig.CHARACTER_TAG))
        {
            Character character = ColliderCache<Character>.GetComponent(collider);
            if (character.GetStat().IsDead)
            {
                return;
            }
            OnDespawn();
            character?.GetStat()?.OnHit(damage);
        }
        else if(collider.CompareTag(GameConfig.OBSTACLE_TAG))
        {
            OnDespawn();
        }
    }
}
