using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image healthBarFollow;
    private Stats stats;

    private void Awake()
    {
        stats = gameObject.GetComponent<Stats>();
    }

    private void Update()
    {
        healthBar.fillAmount = stats.currentHealth / stats.maxHealth;
    }

    private void FixedUpdate()
    {
        if (healthBar.fillAmount < healthBarFollow.fillAmount)
        {
            healthBarFollow.fillAmount -= 0.01f * Time.fixedDeltaTime * 100;
        } else
        {
            healthBarFollow.fillAmount += 0.01f * Time.fixedDeltaTime * 100;
        }
    }
}
