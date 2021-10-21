using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarActivation : MonoBehaviour
{
    [SerializeField] private SacrificeKey.SacrificeKeyType sacrificeKeyType;

    private SacrificeKey sacrifeKeyType;

    public Material glowMaterialA;
    public Material glowMaterialB;

    public SacrificeKey.SacrificeKeyType GetKeyType()
    {
        return sacrificeKeyType;
    }

    public void ActivateAltar()
    {
        Debug.Log("altar" + sacrificeKeyType +  "hit");

        //Turn on glow emmission on activation
        

        //Open doors depending on altar activated       
        if (sacrificeKeyType == SacrificeKey.SacrificeKeyType.TypeA)
        {
            GameObject.FindGameObjectWithTag("DoorA").SetActive(false);
            glowMaterialA.EnableKeyword("_EMISSION");
        }
        else if (sacrificeKeyType == SacrificeKey.SacrificeKeyType.TypeB)
        {
            GameObject.FindGameObjectWithTag("DoorB").SetActive(false);
            glowMaterialB.EnableKeyword("_EMISSION");
        }

        

    }

  
}
