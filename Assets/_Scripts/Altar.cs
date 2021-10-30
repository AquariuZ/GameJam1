using UnityEngine;

public class Altar : MonoBehaviour
{
    public Pickup sacrifice;
    [SerializeField] private AltarPiece[] pieces;

    [SerializeField] private MeshRenderer altarRenderer;
    [SerializeField] private Material activatedMaterial;

    void Awake()
    {
        if(altarRenderer == null)
            altarRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public virtual void Activate()
    {
        sacrifice.Place();
        altarRenderer.material = activatedMaterial;

        foreach (var piece in pieces)
        {
            piece.Activate();
        }
    }
}
