using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class FallingTile : MonoBehaviour
{
    [SerializeField] private int stepCount = 1;
    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private float duration = 2.0f;
    [SerializeField] private AnimationCurve curve;

    [SerializeField] private bool waitAfterExitingTile = true;
    [SerializeField] private float waitingTime = 1.0f;
    
    //Not serialized variables
    private Vector3 _startPosition;
    private int _currentStepCount = 0;
    private MeshRenderer _meshRenderer;
    private BoxCollider _boxCollider;
    private bool _triggered = false;
    private float _timer = 0.0f;
    
    //materials for animation
    private Material crackedMat;
    private Material fallingMat;
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
        //_boxCollider.isTrigger = true;
        _startPosition = transform.position;
        finalPosition = _startPosition + finalPosition;

        crackedMat = Resources.Load<Material>("Materials/cracked");
        fallingMat = Resources.Load<Material>("Materials/falling");
    }

    // Update is called once per frame
    void Update()
    {
        if (_triggered && transform.position != finalPosition)
        {
            _timer += Time.deltaTime;
            float percentage = _timer / duration;
            transform.position = Vector3.Lerp(_startPosition, finalPosition, curve.Evaluate(percentage));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger");
        if (_triggered) return;
        if (!other.gameObject.CompareTag("Player")) return;
        
        _currentStepCount += 1;
        switch (_currentStepCount)
        {
            case 1:
                _meshRenderer.material = crackedMat;
                break;
            case 2:
                _meshRenderer.material = fallingMat;
                break;
            default:
                _meshRenderer.material = fallingMat;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_triggered) return;
        if (!other.gameObject.CompareTag("Player")) return;
        
        if (_currentStepCount >= stepCount)
        {
            //move to the bottom position
            StartCoroutine(WaitForTile());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Entered Collision");
    }

    IEnumerator WaitForTile()
    {
        if (waitAfterExitingTile)
            yield return new WaitForSeconds(waitingTime);

        _triggered = true;
    }
}
