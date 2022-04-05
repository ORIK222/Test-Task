using System.Collections;
using UnityEngine;

public class EnemyAttack : EnemyAbility
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _attackDelay;

    private bool _canAttack = true;

    private const string _attackAnimation = "Attack";

    private void Update()
    {
        if (_instance.CurrentState == EnemyState.Dead)
            return;
        
        if (_distanceChecker.CheckDistanceForAttack() && _canAttack)
            Attack();
    }
    private void Attack()
    {
        _canAttack = false;
        _instance.CurrentState = EnemyState.Attack;
        SetAnimationTrigger(_attackAnimation);
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(_attackDelay / 2);
        if (_instance.CurrentState != EnemyState.TakeDamage)
            _distanceChecker.Target.ApplyDamage(_attackForce);
        yield return new WaitForSeconds(_attackDelay / 2);
        _canAttack = true;
    }
}
