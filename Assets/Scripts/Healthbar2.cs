using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar2 : MonoBehaviour
{
    [SerializeField] private Image Healthbar1;


    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        Healthbar1.fillAmount = currentHealth / maxHealth;
    }
}
