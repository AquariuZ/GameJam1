using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterActivation : MonoBehaviour
{
    [SerializeField] private SacrificeKey.SacrificeKeyType sacrificeKeyType;

    

    public SacrificeKey.SacrificeKeyType GetKeyType()
    {
        return sacrificeKeyType;
    }

    public void ActivateAltar()
    {
        Debug.Log("altar 1 hit");

        //TESTING DO NOT USE
        //GameObject.FindGameObjectWithTag("Door1").SetActive(false);
        //gameObject.SetActive(false);

        //Add glow mat
    }
}
