using System;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TurretHealth _turretHealth;
    [SerializeField] private TextMeshProUGUI _health;

    private void Start()
    {
        _turretHealth.OnHealthChanged += UpdateHealthText;
    }

    private void UpdateHealthText(int health)
    {
        _health.text = health.ToString();
    }
}
