using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SacrificeCounter : MonoBehaviour
{
    public int numSacrifices;

    public Sprite deathSprite;

    public bool Male, Female, Binary, Farmer, Warrior, AnimalCostumed, ArmyCaptive;

    public List<GameObject> SacrificeIcons;

    public List<GameObject> Sacrifices;

    [NonSerialized]
    public int numPeople;

    [NonSerialized]
    public int numSacrificed;

    // Start is called before the first frame update
    void Start()
    {
        numPeople = numSacrifices;
        numSacrificed = 0;

        switch (numSacrifices)
        {
            case 0:
                SacrificeIcons[0].gameObject.SetActive(false);
                SacrificeIcons[1].gameObject.SetActive(false);
                SacrificeIcons[2].gameObject.SetActive(false);
                SacrificeIcons[3].gameObject.SetActive(false);
                SacrificeIcons[4].gameObject.SetActive(false);
                SacrificeIcons[5].gameObject.SetActive(false);
                SacrificeIcons[6].gameObject.SetActive(false);
                SacrificeIcons[7].gameObject.SetActive(false);
                SacrificeIcons[8].gameObject.SetActive(false);
                SacrificeIcons[9].gameObject.SetActive(false);
                
                break;
            case 1:
                SacrificeIcons[0].gameObject.SetActive(true);
                SacrificeIcons[1].gameObject.SetActive(false);
                SacrificeIcons[2].gameObject.SetActive(false);
                SacrificeIcons[3].gameObject.SetActive(false);
                SacrificeIcons[4].gameObject.SetActive(false);
                SacrificeIcons[5].gameObject.SetActive(false);
                SacrificeIcons[6].gameObject.SetActive(false);
                SacrificeIcons[7].gameObject.SetActive(false);
                SacrificeIcons[8].gameObject.SetActive(false);
                SacrificeIcons[9].gameObject.SetActive(false);
                
                break;
            case 2:
                SacrificeIcons[0].gameObject.SetActive(true);
                SacrificeIcons[1].gameObject.SetActive(true);
                SacrificeIcons[2].gameObject.SetActive(false);
                SacrificeIcons[3].gameObject.SetActive(false);
                SacrificeIcons[4].gameObject.SetActive(false);
                SacrificeIcons[5].gameObject.SetActive(false);
                SacrificeIcons[6].gameObject.SetActive(false);
                SacrificeIcons[7].gameObject.SetActive(false);
                SacrificeIcons[8].gameObject.SetActive(false);
                SacrificeIcons[9].gameObject.SetActive(false);
                
                break;
            case 3:
                SacrificeIcons[0].gameObject.SetActive(true);
                SacrificeIcons[1].gameObject.SetActive(true);
                SacrificeIcons[2].gameObject.SetActive(true);
                SacrificeIcons[3].gameObject.SetActive(false);
                SacrificeIcons[4].gameObject.SetActive(false);
                SacrificeIcons[5].gameObject.SetActive(false);
                SacrificeIcons[6].gameObject.SetActive(false);
                SacrificeIcons[7].gameObject.SetActive(false);
                SacrificeIcons[8].gameObject.SetActive(false);
                SacrificeIcons[9].gameObject.SetActive(false);
                
                break;
            case 4:
                SacrificeIcons[0].gameObject.SetActive(true);
                SacrificeIcons[1].gameObject.SetActive(true);
                SacrificeIcons[2].gameObject.SetActive(true);
                SacrificeIcons[3].gameObject.SetActive(true);
                SacrificeIcons[4].gameObject.SetActive(false);
                SacrificeIcons[5].gameObject.SetActive(false);
                SacrificeIcons[6].gameObject.SetActive(false);
                SacrificeIcons[7].gameObject.SetActive(false);
                SacrificeIcons[8].gameObject.SetActive(false);
                SacrificeIcons[9].gameObject.SetActive(false);
                
                break;
            case 5:
                SacrificeIcons[0].gameObject.SetActive(true);
                SacrificeIcons[1].gameObject.SetActive(true);
                SacrificeIcons[2].gameObject.SetActive(true);
                SacrificeIcons[3].gameObject.SetActive(true);
                SacrificeIcons[4].gameObject.SetActive(true);
                SacrificeIcons[5].gameObject.SetActive(false);
                SacrificeIcons[6].gameObject.SetActive(false);
                SacrificeIcons[7].gameObject.SetActive(false);
                SacrificeIcons[8].gameObject.SetActive(false);
                SacrificeIcons[9].gameObject.SetActive(false);
                
                break;
            case 6:
                SacrificeIcons[0].gameObject.SetActive(true);
                SacrificeIcons[1].gameObject.SetActive(true);
                SacrificeIcons[2].gameObject.SetActive(true);
                SacrificeIcons[3].gameObject.SetActive(true);
                SacrificeIcons[4].gameObject.SetActive(true);
                SacrificeIcons[5].gameObject.SetActive(true);
                SacrificeIcons[6].gameObject.SetActive(false);
                SacrificeIcons[7].gameObject.SetActive(false);
                SacrificeIcons[8].gameObject.SetActive(false);
                SacrificeIcons[9].gameObject.SetActive(false);
                
                break;
            case 7:
                SacrificeIcons[0].gameObject.SetActive(true);
                SacrificeIcons[1].gameObject.SetActive(true);
                SacrificeIcons[2].gameObject.SetActive(true);
                SacrificeIcons[3].gameObject.SetActive(true);
                SacrificeIcons[4].gameObject.SetActive(true);
                SacrificeIcons[5].gameObject.SetActive(true);
                SacrificeIcons[6].gameObject.SetActive(true);
                SacrificeIcons[7].gameObject.SetActive(false);
                SacrificeIcons[8].gameObject.SetActive(false);
                SacrificeIcons[9].gameObject.SetActive(false);
                
                break;
            case 8:
                SacrificeIcons[0].gameObject.SetActive(true);
                SacrificeIcons[1].gameObject.SetActive(true);
                SacrificeIcons[2].gameObject.SetActive(true);
                SacrificeIcons[3].gameObject.SetActive(true);
                SacrificeIcons[4].gameObject.SetActive(true);
                SacrificeIcons[5].gameObject.SetActive(true);
                SacrificeIcons[6].gameObject.SetActive(true);
                SacrificeIcons[7].gameObject.SetActive(true);
                SacrificeIcons[8].gameObject.SetActive(false);
                SacrificeIcons[9].gameObject.SetActive(false);
                
                break;
            case 9:
                SacrificeIcons[0].gameObject.SetActive(true);
                SacrificeIcons[1].gameObject.SetActive(true);
                SacrificeIcons[2].gameObject.SetActive(true);
                SacrificeIcons[3].gameObject.SetActive(true);
                SacrificeIcons[4].gameObject.SetActive(true);
                SacrificeIcons[5].gameObject.SetActive(true);
                SacrificeIcons[6].gameObject.SetActive(true);
                SacrificeIcons[7].gameObject.SetActive(true);
                SacrificeIcons[8].gameObject.SetActive(true);
                SacrificeIcons[9].gameObject.SetActive(false);
                
                break;
            case 10:
                SacrificeIcons[0].gameObject.SetActive(true);
                SacrificeIcons[1].gameObject.SetActive(true);
                SacrificeIcons[2].gameObject.SetActive(true);
                SacrificeIcons[3].gameObject.SetActive(true);
                SacrificeIcons[4].gameObject.SetActive(true);
                SacrificeIcons[5].gameObject.SetActive(true);
                SacrificeIcons[6].gameObject.SetActive(true);
                SacrificeIcons[7].gameObject.SetActive(true);
                SacrificeIcons[8].gameObject.SetActive(true);
                SacrificeIcons[9].gameObject.SetActive(true);
                
                break;
        }

        if (Male == true)
        {
            for (int i = 0; i < numSacrifices; i++)
            {
                SacrificeIcons[i].GetComponent<Image>().color = Color.blue;
            }
        }

        if (Female == true)
        {
            for (int i = 0; i < numSacrifices; i++)
            {
                SacrificeIcons[i].GetComponent<Image>().color = Color.magenta;
            }
        }

        if (Binary == true)
        {
            for (int i = 0; i < numSacrifices; i++)
            {
                SacrificeIcons[i].GetComponent<Image>().color = Color.green;
            }
        }

        if (Farmer == true)
        {
            for (int i = 0; i < numSacrifices; i++)
            {
                SacrificeIcons[i].GetComponent<Image>().color = Color.yellow;
            }
        }

        if (Warrior == true)
        {
            for (int i = 0; i < numSacrifices; i++)
            {
                SacrificeIcons[i].GetComponent<Image>().color = Color.red;
            }
        }

        if (AnimalCostumed == true)
        {
            for (int i = 0; i < numSacrifices; i++)
            {
                SacrificeIcons[i].GetComponent<Image>().color = Color.cyan;
            }
        }

        if (ArmyCaptive == true)
        {
            for (int i = 0; i < numSacrifices; i++)
            {
                SacrificeIcons[i].GetComponent<Image>().color = Color.grey;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int j = 0; j < numPeople; j++)
        {
            if (Sacrifices[j].activeSelf == false)
            {
                SacrificeIcons[j].GetComponent<Image>().sprite = deathSprite;
            }
        }
    }
}
