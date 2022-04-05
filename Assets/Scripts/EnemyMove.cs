using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyAbility
{
    [SerializeField] private float _speed;

    private const string _walkAnimation = "Walk";
 
    private void Update()
    {
        if (_instance.CurrentState == EnemyState.Dead)
            return;
        if (_instance.CurrentState == EnemyState.Attack)
        {
            SetAnimationBool(_walkAnimation, false);
            return;
        }

        else if (_distanceChecker.CheckDistanceForStalking() && !_distanceChecker.CheckDistanceForAttack())
            GoToTarget();
        else if (!_distanceChecker.CheckDistanceForStalking())
            SetAnimationBool(_walkAnimation, false);
    }

    private void GoToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _distanceChecker.Target.transform.position, _speed * Time.deltaTime);
        transform.LookAt(_distanceChecker.Target.transform);
        SetAnimationBool(_walkAnimation, true);
    }
}
