using System;
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

    [SerializeField] private Vector3 offSet;

    [SerializeField] private Vector3 targetOffset;

    [SerializeField] private Vector3 rotationEulerTarget;

    public void OnInit()
    {
        target = tfPlayer;
        cam.fieldOfView = 60f;
        tf.rotation = Quaternion.Euler(rotationEulerPlay);
    }

    public Camera GetCam()
    {
        return cam;
    }

    public void OnStartGame()
    {
        SetTargetOffSet(offSetPlay);
    }

    public void OnMenuGame()
    {
        SetTargetOffSet(offSetMainMenu);
    }

    public void ChangeOffSetByRange(float range)
    {
        SetTargetOffSet(offSetPlay*(range/5f));
    }
    public void SmoothChangeOffSet()
    {
        if((targetOffset- offSet).sqrMagnitude > 0.001f)
        {
            offSet = Vector3.Lerp(offSet, targetOffset, speed*Time.deltaTime);
        }
    }

    public void SmoothChangeRotation()
    {
        //tf.rotation = Quaternion.Slerp(tf.rotation, )
    }
    public void SetTargetOffSet(Vector3 _targetOffSet)
    {
        targetOffset = _targetOffSet;
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
        SmoothChangeOffSet();
        tf.position = offSet + target.position;
        
    }
}
