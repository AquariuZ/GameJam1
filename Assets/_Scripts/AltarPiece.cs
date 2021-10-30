using UnityEngine;

public class AltarPiece : MonoBehaviour
{
    public virtual void Activate()
    {
        Debug.Log($"Activated alter piece: {gameObject.name}");
    }
}