using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbles : MonoBehaviour
{
    public string FlavorText = "Enter Text Here";
    [SerializeField] private KeyCode FinishDialogueKey;
    public GameObject Sacrifice;
    PickupPerson pickupPerson;
    private bool isActivated;
    private bool timeUp;

    void Start()
    {
        isActivated = false;
        timeUp = false;
        pickupPerson = Sacrifice.GetComponent<PickupPerson>();
    }

    void OnGUI()
    {
        // Make a multiline text area that modifies stringToEdit.
        if (timeUp != true)
        {
            if (isActivated)
            {
                FlavorText = GUI.TextArea(new Rect(300, 310, 300, 80), FlavorText, 200);
            }
        }
    }

    void Update()
    {
        if (pickupPerson.follow)
        {
            isActivated = true;
        }
        if (Input.GetKeyDown(FinishDialogueKey) && pickupPerson.follow)
        {
            timeUp = true;
        }
    }
}
