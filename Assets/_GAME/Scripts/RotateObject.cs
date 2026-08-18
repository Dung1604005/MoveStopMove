using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private bool rotateByZ;

    [SerializeField] private float rotateSpeed;

    private float timer = 0f;

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
