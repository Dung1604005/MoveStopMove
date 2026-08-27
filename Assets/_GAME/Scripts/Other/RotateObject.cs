using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Transform tf;

    [SerializeField] private Vector3 rotateDirect;

    [SerializeField] private float rotateSpeed;

    private float timer = 0f;

    void Update()
    {
        tf.Rotate(rotateDirect.x*rotateSpeed*Time.deltaTime,
         rotateDirect.y*rotateSpeed*Time.deltaTime,
          rotateDirect.z*rotateSpeed*Time.deltaTime);
    }
}
