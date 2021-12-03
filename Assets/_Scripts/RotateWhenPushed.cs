using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotateWhenPushed : MonoBehaviour
{
    [SerializeField] private string tagOfPusher = "Player";
    [SerializeField] private Transform moveTransform = null;
    [SerializeField] private Vector3 moveOffset = Vector3.zero;
    [SerializeField] private Transform rotateTransform = null;
    [SerializeField] private Vector3 rotateOffset = Vector3.zero;
    [SerializeField] private float moveDuration = 1.0f;
    [SerializeField] private Ease easeType = Ease.OutBack;
    [SerializeField] private bool hideOnComplete = false;

    private bool activated = false;

    private void Start()
    {
        Debug.Log("Started");
    }

    public void Activate()
    {
        if (moveTransform == null)
            moveTransform = transform;
        if (rotateTransform == null)
            rotateTransform = transform;

        if (moveOffset != Vector3.zero)
        {
            moveTransform.DOMove(moveTransform.position + moveOffset, moveDuration).SetEase(easeType)
                .OnComplete(() =>
                {
                    if (hideOnComplete)
                        gameObject.SetActive(false);
                });
        }

        if (rotateOffset != Vector3.zero)
        {
            rotateTransform.DORotate(rotateTransform.rotation.eulerAngles + rotateOffset, moveDuration).SetEase(easeType)
                .OnComplete(() =>
                {
                    if (hideOnComplete)
                        gameObject.SetActive(false);
                });
        }
        
        activated = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activated)
        {
            if (other.gameObject.CompareTag(tagOfPusher))
            {
                Activate();
                Debug.Log("Colliding");
            }
        }
    }
}
