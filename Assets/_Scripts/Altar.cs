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

        if(VFX_StartEvent != "")
            VFX_StartEventHash = Shader.PropertyToID(VFX_StartEvent);
    }

    public virtual void Activate()
    {
        Debug.Log($"Activating altar: {name}");

        if(sacrifice != null)
            sacrifice.Place();

        if(altarRenderer != null && activatedMaterial != null)
            altarRenderer.material = activatedMaterial;

        if(VFX != null)
            VFX.SendEvent(VFX_StartEventHash);

        foreach (var piece in pieces)
        {
            piece.Activate();
        }
    }
}
