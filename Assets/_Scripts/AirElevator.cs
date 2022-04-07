using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirElevator : AltarPiece
{
    
    public bool isActivated = false;
    public float timeLapse = 1.0f;
    
    public Transform _startPoint;
    public Transform _middlePoint;
    public Transform _endPoint;

    private Vector3 _pointAB;
    private Vector3 _pointBC;

    private PlayerController _playerRef;
    private bool _isWorking;
    private float _interpolateAmount;
    private float _timer;

    // Update is called once per frame
    void LateUpdate() //so it doesn't care about input.
    {
        if (_isWorking)
        {
            if (_interpolateAmount > 1.0f)
            {
                //is done
                _playerRef.transform.Find("GroundCheck").gameObject.SetActive(true);
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
            
            _timer += Time.deltaTime;
            _interpolateAmount = _timer / timeLapse;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundCheck"))
        {
            if (isActivated)
            {
                _isWorking = true;
                _playerRef = other.gameObject.GetComponentInParent<PlayerController>();
                _playerRef.transform.Find("GroundCheck").gameObject.SetActive(false);
                _timer = 0.0f;
                _interpolateAmount = 0.0f;
            }
        }
    }

    public override void Activate()
    {
        base.Activate();
        isActivated = true;
    }
}
