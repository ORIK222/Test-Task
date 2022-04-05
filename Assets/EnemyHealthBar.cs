using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private HealthBar _healthBar;

    private void OnEnable() => _enemy.ApllyDamageEvents += UpdateHealthBar;
    private void OnDisable() => _enemy.ApllyDamageEvents -= UpdateHealthBar;
    private void UpdateHealthBar(float current, float max) => _healthBar.SetHealthBarValue(current, max);
}
