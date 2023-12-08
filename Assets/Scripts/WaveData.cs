using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    public float minute;
    public float second;
    public GameObject enemy;
    public int amount;
}


[CreateAssetMenu]
public class WaveData : ScriptableObject
{
    public List<Wave> events;
}
