using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_Controller : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    [Header("Position")]
    
    [SerializeField] private Vector3 _startPosition;

    [SerializeField] private Vector3 _endPos;

    [SerializeField] [Range(0,20)] private float _lerpTime;

    [Header("Rotation")] 
    [SerializeField] private Vector3 startRotation;

    [SerializeField] private Vector3 endRotation;
    void Start()
    {
        _cam = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateCameraPosition(_endPos);
            UpdateCameraRotation(endRotation);
        }
        else
        {
            UpdateCameraPosition(_startPosition);

            UpdateCameraRotation(startRotation);
        }
    }

    private void UpdateCameraPosition(Vector3 _target)
    {
        _cam.transform.position = Vector3.Lerp(_cam.transform.position,_target,_lerpTime * Time.deltaTime);   
    }

    private void UpdateCameraRotation(Vector3 _target)
    {
        _cam.transform.rotation = Quaternion.Slerp(_cam.transform.rotation, Quaternion.Euler(_target), _lerpTime*Time.deltaTime);
    }
}
