using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image Healthbar2;
    

    public void UpdateHealthBar(float maxHealth,float currentHealth)
    {
        Healthbar2.fillAmount = currentHealth / maxHealth;
    }
}
