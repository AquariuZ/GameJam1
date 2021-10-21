using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeKey : MonoBehaviour
{
    [SerializeField] private SacrificeKeyType sacrificeKeyType;

    public enum SacrificeKeyType
    {
        TypeA,
        TypeB,
        TypeC,
        TypeD,
    }

    public SacrificeKeyType GetKeyType()
    {
        return sacrificeKeyType;
    }
}
