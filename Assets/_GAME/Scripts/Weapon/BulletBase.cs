using UnityEngine;

public class BulletBase : GameUnit
{
    [SerializeField] private Vector3 defaultScale;
    [SerializeField] private Vector3 moveDir;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float damage;

    [SerializeField] private float liveTime;

    [SerializeField] private float timerLive;

    [SerializeField] private Character owner;

    
    public void LoadData(Vector3 _moveDir, float _moveSpeed, float _damage, Character _owner)
    {
        moveDir = _moveDir;
        moveSpeed = _moveSpeed;
        damage = _damage;
        timerLive = 0f;
        owner = _owner;
        SetSize(_owner.GetStat().Size);
        tf.rotation = Quaternion.LookRotation(moveDir);
    }

    public void SetSize(float size)
    {
        tf.localScale = defaultScale*size;
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
        if(owner != null && owner.GetStat().IsDead)
        {
            OnDespawn();
        }
        if(timerLive >= liveTime )
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
            character?.GetStat()?.OnHit(damage,owner );
        }
        else if(collider.CompareTag(GameConfig.OBSTACLE_TAG))
        {
            OnDespawn();
        }
    }
}
