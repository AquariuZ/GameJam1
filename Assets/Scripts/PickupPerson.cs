using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPerson : MonoBehaviour
{
    public bool canPickup = true;
    public bool isPickedUp = false;
    public GameObject myHands;


    private void Update()
    {
        if (canPickup = true && Input.GetKeyDown("e"))
        {
            transform.parent = myHands.transform;   //Attach sacrificed body to hands
            isPickedUp = true;
        }
        if (isPickedUp = true && Input.GetKeyDown("q"))
        {
            transform.parent = null;                //Drop sacrificed body
            isPickedUp = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPickup = true;
            Debug.Log("hdbfhdsbf");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPickup = false;
        }
    }


}
