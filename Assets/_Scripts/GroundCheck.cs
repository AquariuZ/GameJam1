using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float timeInAirTillDeath = 0.3f;
    private List<Collider> _colliders;
    private float _timer;
    
    

    private void Awake()
    {
        _colliders = new List<Collider>();
    }

    private void Update()
    {
        
        // if(transform.position.y < -8)
        // {
        //     UnityEngine.SceneManagement.SceneManager.LoadScene(
        //             UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        //             );
        // }
    }

    private void FixedUpdate()
    {
        IsGrounded2();
    }

    private bool IsGrounded2()
    {
        if (_colliders.Count > 0)
        {
            _timer = 0.0f;
            return true;
        }
        else
        {
            if (_timer >= timeInAirTillDeath)
            {
                _timer = 0.0f;
                UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
                );
            }

            _timer += Time.fixedDeltaTime;
            return false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _colliders.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _colliders.Remove(other);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity,
            LayerMask.NameToLayer("Ground")))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("Did not Hit");
            return false;
        }
    }

    private void OnDisable()
    {
        _colliders.Clear();
    }
}

