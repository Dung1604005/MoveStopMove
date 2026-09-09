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
    }

    public Camera GetCam()
    {
        return cam;
    }

    public void SetActive(bool active)
    {
        tf.gameObject.SetActive(active);
    }

    public void OnStartGame()
    {
        SetTargetOffSet(offSetPlay);
        SetTargetRotation(rotationEulerPlay);
    }

    public void OnMainMenu()
    {
        SetTargetOffSet(offSetMainMenu);
        SetTargetRotation(rotationEulerMainMenu);
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
        tf.rotation = Quaternion.Slerp(tf.rotation, Quaternion.Euler(rotationEulerTarget) , speed*Time.deltaTime);
    }
    public void SetTargetOffSet(Vector3 _targetOffSet)
    {
        targetOffset = _targetOffSet;
    }

    public void SetTargetRotation(Vector3 _target)
    {
        rotationEulerTarget = _target;
    }

    void Awake()
    {
        OnInit();
    }


    void LateUpdate()
    {
        if(target == null)
        {
            return;
        }
        SmoothChangeOffSet();
        SmoothChangeRotation();
        tf.position = offSet + target.position;
        
    }
}

public enum CameraType
{
    MainCamera = 0,
    UIWorldCamera = 1
}
