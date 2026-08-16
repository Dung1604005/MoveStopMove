using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offSetPlaying;

    [SerializeField] private Vector3 rotationEuler;

    [SerializeField] private Camera cam;

    [SerializeField] private Transform tfPlayer;

    [SerializeField] private float speed ;

    [SerializeField]private Transform tf;

    [SerializeField]private Transform target;

    private Vector3 offSet = Vector3.zero;


    public void OnInit()
    {
        offSet = offSetPlaying;
        target = tfPlayer;
        cam.fieldOfView = 60f;
        tf.rotation = Quaternion.Euler(rotationEuler);
    }

    void Awake()
    {
        tf = this.transform;
        OnInit();
    }


    void LateUpdate()
    {
        if(target == null)
        {
            return;
        }
        
        tf.position = offSet + target.position;
        
    }
}
