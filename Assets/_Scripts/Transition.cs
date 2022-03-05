using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] private CanvasGroup Title;

    [SerializeField] private bool fadeIn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if(Title.alpha < 1)
            {
                Title.alpha += Time.deltaTime;
                if (Title.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }
}
