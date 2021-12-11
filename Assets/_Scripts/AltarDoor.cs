using DG.Tweening;
using UnityEngine;

public class AltarDoor : AltarPiece
{
    [SerializeField] private Transform moveTransform = null;
    [SerializeField] private Vector3 moveOffset = Vector3.zero;
    [SerializeField] private Transform rotateTransform = null;
    [SerializeField] private Vector3 rotateOffset = Vector3.zero;
    [SerializeField] private float moveDuration = 1.0f;
    [SerializeField] private Ease easeType = Ease.OutBack;
    [SerializeField] private bool hideOnComplete = false;

    private Vector3 startPos;
    private Quaternion startRot;

    void Awake()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public override void Activate()
    {
        base.Activate();

        if (moveTransform == null)
            moveTransform = transform;

        if (rotateTransform == null)
            rotateTransform = transform;

        if (moveOffset != Vector3.zero && moveTransform.position == startPos)
        {
            moveTransform.DOMove(transform.position + moveOffset, moveDuration).SetEase(easeType).OnComplete(() =>
            {
                if (hideOnComplete)
                    gameObject.SetActive(false);
            });
        }

        if (rotateOffset != Vector3.zero && rotateTransform.rotation == startRot)
        {
            rotateTransform.DORotate(transform.rotation.eulerAngles + rotateOffset, moveDuration).SetEase(easeType).OnComplete(() =>
            {
                if (hideOnComplete)
                    gameObject.SetActive(false);
            });
        }
    }
}