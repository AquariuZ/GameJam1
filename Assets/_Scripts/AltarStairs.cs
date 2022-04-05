using System;
using DG.Tweening;
using UnityEngine;

public class AltarStairs : AltarPiece
{
    [SerializeField] private float moveDuration = 1.0f;
    [SerializeField] private Ease easeType = Ease.OutBack;
    [SerializeField] private Vector3 position1;
    [SerializeField] private Vector3 position2;
    
    [NonSerialized]
    public bool activated = false;

    public override void Activate()
    {
        base.Activate();
        if (transform.position == position1)
        {
            transform.DOMove(position2, moveDuration).SetEase(easeType).OnComplete(() =>
            {
                
            });
        }
        else if (transform.position == position2)
        {
            transform.DOMove(position1, moveDuration).SetEase(easeType).OnComplete(() =>
            {
                
            });
        }
    }
}
