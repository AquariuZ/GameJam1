using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbles : MonoBehaviour
{
    public string FlavorText = "Enter Text Here";
    public GameObject Sacrifice;
    PickupPerson pickupPerson;
    private bool isActivated;

    void Start()
    {
        isActivated = false;
        pickupPerson = Sacrifice.GetComponent<PickupPerson>();
    }

    void OnGUI()
    {
        // Make a multiline text area that modifies stringToEdit.
        if (isActivated)
        {
            FlavorText = GUI.TextArea(new Rect(300, 310, 300, 80), FlavorText, 200);
        }
    }

    void Update()
    {
        if (pickupPerson.follow)
        {
            isActivated = true;
        }
    }
}
