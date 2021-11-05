using DG.Tweening;
using UnityEngine;

public class AltarDoor : AltarPiece
{
    [SerializeField] private Vector3 moveOffset = Vector3.zero;
    [SerializeField] private float moveDuration = 1.0f;
    [SerializeField] private Ease easeType = Ease.OutBack;
    public override void Activate()
    {
        base.Activate();
        transform.DOMove(transform.position + moveOffset, moveDuration).SetEase(easeType).OnComplete(() => gameObject.SetActive(false));
    }
}