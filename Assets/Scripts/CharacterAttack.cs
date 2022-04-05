using System;
using System.Collections;
using UnityEngine;

public class CharacterAttack : CharacterAbility
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _attackForce;
    [SerializeField] private float _attackDelay;

    private bool _canAttack;
    private const string _attackAnimation = "Attack";
    private Action _recoveryEvent;

    private void OnEnable() => _recoveryEvent += OnRecovery;
    private void OnDisable() => _recoveryEvent -= OnRecovery;

    private void Start()
    {
        _weapon.AttackForce = _attackForce;
        _canAttack = true;
    }
    private void Update()
    {
        if (_canAttack == false || _currentState == CharacterState.Dead)
            return;

        if(_leftMouseButtonClick)
            Attack();
    }

    private void Attack()
    {
        if (_currentState == CharacterState.Attack)
            return;

        _currentState = CharacterState.Attack;
        SetAnimationTrigger(_attackAnimation);    
        _recoveryEvent?.Invoke();
    }
    private void OnRecovery()
    {
        StartCoroutine(RecoveryCoroutine());
    }
    private IEnumerator RecoveryCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _weapon.Attack();
        yield return new WaitForSeconds(1.5f);
        ChangeState(CharacterState.Idle);
    }
}
