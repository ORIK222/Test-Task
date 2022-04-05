using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterAbility
{
    public Action<float, float> UpdateHealthEvent;
    public Action DeadEvent;

    [SerializeField] private float _health;

    private float _currentHealth;
    private const string _applyDamageAnimation = "TakeDamage";
    private const string _deadAnimation = "Dead";

    private void Start()
    {
        _currentHealth = _health;
    }
    public void ApplyDamage(float damage)
    {
        if (_currentState == CharacterState.Dead)
            return;

        _currentHealth -= damage;
        UpdateHealthEvent?.Invoke(_currentHealth, _health);
        SetAnimationTrigger(_applyDamageAnimation);
        if (_currentHealth <= 0)
            Dead();
    }

    public void BoostHealth()
    {
        UpdateHealthEvent?.Invoke(++_currentHealth, _health);
    }
    private void Dead()
    {
        SetAnimationBool(_deadAnimation, true);
        _currentState = CharacterState.Dead;
        DeadEvent?.Invoke();
    }
}
