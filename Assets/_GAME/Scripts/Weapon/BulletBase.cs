using UnityEngine;

public class BulletBase : GameUnit
{
    [SerializeField] private Vector2 moveDir;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float damage;
    
    public void LoadData(Vector2 _moveDir, float _moveSpeed, float _damage)
    {
        moveDir = _moveDir;
        moveSpeed = _moveSpeed;
        damage = _damage;
    }

    public void Move()
    {
        Vector3 moveDir3D = new Vector3(moveDir.x, 0f, moveDir.y);
        tf.position = Vector3.MoveTowards(tf.position, tf.position + moveDir3D, moveSpeed*Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        Move();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(GameConfig.CHARACTER_TAG))
        {
            Character character = ColliderCache<Character>.GetComponent(collider);

            character?.GetStat()?.OnHit(damage);
        }
    }
}
