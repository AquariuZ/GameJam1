using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private KeyCode pickupKey;
    [SerializeField] private KeyCode sacrificeKey;

    [SerializeField] private LayerMask altarLayerMask;
    [SerializeField] private LayerMask pickupLayerMask;

    [SerializeField] private float pickupRadius = 5f;
    [SerializeField] private float sacrificeRadius = 5f;

    private Collider[] nonAllocCollider = new Collider[1];
    private PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(pickupKey))
        {
            if (Physics.OverlapSphereNonAlloc(transform.position, pickupRadius, nonAllocCollider, pickupLayerMask) > 0)
            {
                var pickup = nonAllocCollider[0].GetComponentInParent<Pickup>();
                if (pickup != null)
                {
                    if (!playerController.pickups.Contains(pickup))
                    {
                        pickup.Take();

                        playerController.pickups.Add(pickup);
                    }
                }
            }
        }

        if (Input.GetKeyDown(sacrificeKey))
        {
            if (Physics.OverlapSphereNonAlloc(transform.position, pickupRadius, nonAllocCollider, altarLayerMask) > 0)
            {
                var foundAltar = nonAllocCollider[0].GetComponentInParent<Altar>();
                if (foundAltar != null)
                {
                    if (foundAltar.sacrifice == null)
                    {
                        foundAltar.Activate();
                    }
                    else
                    {
                        if (!foundAltar.CanBeActivated()) return;
                        foreach (var sacrifice in foundAltar.sacrifice)
                        {
                            if (playerController.pickups.Contains(sacrifice))
                            {
                                foundAltar.Activate();
                                sacrifice.Place();
                                playerController.pickups.Remove(sacrifice);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
