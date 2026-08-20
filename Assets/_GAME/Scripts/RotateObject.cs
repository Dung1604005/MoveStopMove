using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Transform tf;
    [SerializeField] private bool rotateByZ;

    [SerializeField] private float rotateSpeed;

    private float timer = 0f;

    void Update()
    {
        tf.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
