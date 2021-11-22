using UnityEngine;
using UnityEngine.VFX;

public class Altar : MonoBehaviour
{
    public Pickup sacrifice;
    [SerializeField] private AltarPiece[] pieces;

    [SerializeField] private MeshRenderer altarRenderer;
    [SerializeField] private Material activatedMaterial;

    [SerializeField] private VisualEffect VFX;
    [SerializeField] private string VFX_StartEvent;

    private int VFX_StartEventHash;

    void Awake()
    {
        if(altarRenderer == null)
            altarRenderer = GetComponentInChildren<MeshRenderer>();

        VFX_StartEventHash = Shader.PropertyToID(VFX_StartEvent);
    }

    public virtual void Activate()
    {
        Debug.Log($"Activating altar: {name}");
        sacrifice.Place();
        altarRenderer.material = activatedMaterial;

        VFX.SendEvent(VFX_StartEventHash);

        foreach (var piece in pieces)
        {
            piece.Activate();
        }
    }
}
