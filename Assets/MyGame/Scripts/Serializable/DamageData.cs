using UnityEngine;
using System;


[Serializable]
public class DamageData
{
    public GameObject parent = null;
    public GameObject effectPrefab = null;
    public float damage = 0f;
    public Vector3 knockDirection = Vector3.zero;

}
