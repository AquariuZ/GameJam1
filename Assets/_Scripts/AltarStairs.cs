using System;
using DG.Tweening;
using UnityEngine;

public class AltarStairs : AltarPiece
{
    [SerializeField] private float moveDuration = 1.0f;
    [SerializeField] private Ease easeType = Ease.OutBack;
    [SerializeField] private Vector3 position1;
    [SerializeField] private Vector3 position2;

    private bool pos1 = true;
    
    [NonSerialized]
    public bool activated = false;

    public override void Activate()
    {
        base.Activate();
        if (pos1)
        {
            transform.DOMove(position2, moveDuration).SetEase(easeType).OnComplete(() =>
            {
                pos1 = false;
            });
        }
        else
        {
            transform.DOMove(position1, moveDuration).SetEase(easeType).OnComplete(() =>
            {
                pos1 = true;
            });
        }
    }
}
