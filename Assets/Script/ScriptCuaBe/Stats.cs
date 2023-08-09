using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Need To Import")]
    [SerializeField] private ScriptableDataStats dataLoad;
    [SerializeField] private int typeSoldier;
    [Header("Stats Overal")]
    public string name;
    public float maxHealth;
    [Header("Stats Currently")]
    public float currentHealth;

    private void Awake ()
    {
        getFromData();
    }

    private void Update ()
    {
        deadFunction();
    }


    // -- Function import Data vao Stats
    public void getFromData()
    {
        maxHealth = dataLoad.soldier[typeSoldier].soldierHealth;
        currentHealth = maxHealth;
        name = dataLoad.soldier[typeSoldier].soldierName;
    }
    // -- Function tru mau khi dame.
    public void getDamageFunction(float amount)
    {
        currentHealth -= amount;
    }
    // -- Function hoi mau.
    public void healInstantFunction(float amount)
    {
        currentHealth += amount;
    }
    // -- Function chet.
    public void deadFunction() {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    // -- Function Deal Dame
    
    // -- ... Muon function gi tuong tac voi Stats nua.
    
}
