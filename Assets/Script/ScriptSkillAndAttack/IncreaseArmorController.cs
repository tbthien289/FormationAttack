using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseArmorController : MonoBehaviour
{
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private float armorIncrease;
    [SerializeField] private float timeBuff;

    public void IncreaseArmor()
    {
        shieldObject.SetActive(true);
        GetComponent<Stats>().currentArmor += armorIncrease;
        Invoke("ResetIncreaseArmor", timeBuff);    
    }

    private void ResetIncreaseArmor()
    {
        shieldObject.SetActive(false);
        GetComponent<Stats>().currentArmor -= armorIncrease;
    }
}
