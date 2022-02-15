using System;
using UnityEngine.AI;

public class PickupPerson : Pickup
{
    public float stoppingDistance = 2f;

    [NonSerialized]
    public bool follow = false;
    private NavMeshAgent navAgent;

    void Awake()
    {
        navAgent = GetComponentInChildren<NavMeshAgent>();
        navAgent.stoppingDistance = stoppingDistance;
    }

    public override void Take()
    {
        base.Take();
        follow = true;
    }
    public override void Place()
    {
        base.Place();
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (follow)
        {
            navAgent.SetDestination(PlayerController.player.transform.position);
        }
    }
}
