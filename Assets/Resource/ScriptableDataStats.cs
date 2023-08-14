using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataDONTKNOWNAME", menuName = "Data/Data")]

public class ScriptableDataStats : ScriptableObject
{
    public List<Soldier> soldier = new List<Soldier>();
}

[Serializable]

public class Soldier
{
    public string soldierName;
    public float soldierHealth;
    public float soldierDamage;
    public float soldierArmor;
}
