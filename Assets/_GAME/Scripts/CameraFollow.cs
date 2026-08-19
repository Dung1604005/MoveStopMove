using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offSetPlayer;

    [SerializeField] private Vector3 growthLvUpCamera;

    [SerializeField] private Vector3 rotationEuler;

    [SerializeField] private Camera cam;

    [SerializeField] private Transform tfPlayer;

    [SerializeField] private float speed;

    [SerializeField]private Transform tf;

    [SerializeField]private Transform target;

    [SerializeField] private Vector3 offSet = Vector3.zero;

    [SerializeField] private Vector3 targetOffsetPlayer;


    public void OnInit()
    {
        offSet = offSetPlayer;
        targetOffsetPlayer = offSetPlayer;
        target = tfPlayer;
        cam.fieldOfView = 60f;
        tf.rotation = Quaternion.Euler(rotationEuler);
    }

    public void UpOffset()
    {
        targetOffsetPlayer += growthLvUpCamera;
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
        

        if((targetOffsetPlayer- offSet).sqrMagnitude > 0.1f)
        {
            offSet = Vector3.Lerp(offSet, targetOffsetPlayer, speed*Time.deltaTime);
        }
        tf.position = offSet + target.position;
        
    }
}
