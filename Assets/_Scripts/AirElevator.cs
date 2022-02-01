using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirElevator : MonoBehaviour
{
    
    public bool isActivated = true;
    public float time = 1.0f;
    
    private Transform _startPoint;
    private Transform _middlePoint;
    private Transform _endPoint;

    [SerializeField] Vector3 _pointAB;
    private Vector3 _pointBC;

    private GameObject _playerRef;
    private bool _isWorking;
    [SerializeField] private float _interpolateAmount;
    void Start()
    {
        _startPoint = transform.Find("StartPoint");
        _middlePoint = transform.Find("MiddlePoint");
        _endPoint = transform.Find("EndPoint");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_isWorking)
        {
            if (_interpolateAmount > 1.0f)
            {
                _isWorking = false;
                return;
            }
            
            //spline between points.
            //lerp between start - middle
            //lerp between middle- end
            //lerp between the last 2.
            _pointAB = Vector3.Lerp(_startPoint.position, _middlePoint.position, _interpolateAmount);
            _pointBC = Vector3.Lerp(_middlePoint.position, _endPoint.position, _interpolateAmount);
            _playerRef.transform.position =  Vector3.Lerp(_pointAB, _pointBC, _interpolateAmount);
            
            _interpolateAmount = (_interpolateAmount + Time.deltaTime) / time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isActivated)
            {
                _isWorking = true;
                _playerRef = other.gameObject;
            }
        }
    }
}
