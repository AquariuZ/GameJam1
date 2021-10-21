using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarActivation : MonoBehaviour
{
    [SerializeField] private SacrificeKey.SacrificeKeyType sacrificeKeyType;

    private SacrificeKey sacrifeKeyType;


    public SacrificeKey.SacrificeKeyType GetKeyType()
    {
        return sacrificeKeyType;
    }

    public void ActivateAltar()
    {
        Debug.Log("altar" + sacrificeKeyType +  "hit");

        //TESTING DO NOT USE
        //GameObject.FindGameObjectWithTag("Door1").SetActive(false);
        //gameObject.SetActive(false);
        
        if (sacrificeKeyType == SacrificeKey.SacrificeKeyType.TypeA)
        {
            GameObject.FindGameObjectWithTag("DoorA").SetActive(false);
        }
        else if (sacrificeKeyType == SacrificeKey.SacrificeKeyType.TypeB)
        {
            GameObject.FindGameObjectWithTag("DoorB").SetActive(false);
        }

        //Add glow mat
    }

  
}
