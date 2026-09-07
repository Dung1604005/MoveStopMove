using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Play Config")]
    [SerializeField] private Vector3 offSetPlay;

    [SerializeField] private Vector3 rotationEulerPlay;

    [Header("MainMenu Config")]

    [SerializeField] private Vector3 offSetMainMenu;

    [SerializeField] private Vector3 rotationEulerMainMenu;

    [SerializeField] private Camera cam;

    [SerializeField] private Transform tfPlayer;

    [SerializeField] private float speed;

    [SerializeField]private Transform tf;

    [SerializeField]private Transform target;

    [SerializeField] private Vector3 offSet = Vector3.zero;

    [SerializeField] private Vector3 targetOffsetPlayer;

    public void OnInit()
    {
        offSet = offSetPlay;
        targetOffsetPlayer = offSetPlay;
        target = tfPlayer;
        cam.fieldOfView = 60f;
        tf.rotation = Quaternion.Euler(rotationEulerPlay);
    }

    public Camera GetCam()
    {
        return cam;
    }

    public void ChangeOffSet(float range)
    {
        
        targetOffsetPlayer = offSetPlay * (range/5f);
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
        

        if((targetOffsetPlayer- offSet).sqrMagnitude > 0.001f)
        {
            offSet = Vector3.Lerp(offSet, targetOffsetPlayer, speed*Time.deltaTime);
        }
        tf.position = offSet + target.position;
        
    }
}
