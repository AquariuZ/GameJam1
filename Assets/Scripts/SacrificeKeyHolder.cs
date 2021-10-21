using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeKeyHolder : MonoBehaviour
{
    private List<SacrificeKey.SacrificeKeyType> sacrificeKeyList;
   

    private void Awake()
    {
        sacrificeKeyList = new List<SacrificeKey.SacrificeKeyType>();
    }

    public void AddKey(SacrificeKey.SacrificeKeyType sacrificeKeyType)
    {
        sacrificeKeyList.Add(sacrificeKeyType);
    }

    public void RemoveKey(SacrificeKey.SacrificeKeyType sacrificeKeyType)
    {
        sacrificeKeyList.Remove(sacrificeKeyType);
    }

    public bool ContainsKey(SacrificeKey.SacrificeKeyType sacrificeKeyType)
    {
        return sacrificeKeyList.Contains(sacrificeKeyType);
    }


    private void OnTriggerEnter(Collider collider)
    {
        SacrificeKey sacrificeKey = collider.GetComponent<SacrificeKey>();

        if (sacrificeKey != null)
        {
            AddKey(sacrificeKey.GetKeyType());
            Destroy(sacrificeKey.gameObject);
        }

        AltarActivation altarActivation = collider.GetComponent<AltarActivation>();

        if (altarActivation != null)
        {
            if (ContainsKey(altarActivation.GetKeyType()))
            {
                RemoveKey(altarActivation.GetKeyType());
                altarActivation.ActivateAltar();
                
            }
        }

        

    }

}
