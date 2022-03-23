using System;
using UnityEngine;
using UnityEngine.AI;

public class PickupPerson : Pickup
{
    public float stoppingDistance = 2f;

    [NonSerialized]
    public bool follow = false;
    [NonSerialized]
    public NavMeshAgent navAgent;

    void Awake()
    {
        navAgent = GetComponentInChildren<NavMeshAgent>();
        navAgent.stoppingDistance = stoppingDistance;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0.0f, transform.rotation.y, transform.rotation.z);
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
