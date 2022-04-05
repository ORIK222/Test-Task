using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : EnemyAbility
{
    public Action<float, float> ApllyDamageEvents;

    [SerializeField] private HealthSphere _healthSpherePrefab;
    [SerializeField] private float _health;
    [SerializeField] private float _respawnDelay;
    [SerializeField] private float _reswpawnRadius;
    
    private float _startHealth;
    private const string _applyDamageAnimation = "ApplyDamage";
    private const string _deadAnimation = "Dead";
    private const string _respawnAnimation = "Respawn";

    private ScoreView _scoreView;

    private void Start()
    {
        _scoreView = FindObjectOfType<ScoreView>();
        _startHealth = _health;
    }
    public void TakeDamage(float damage)
    {
        if (_instance.CurrentState == EnemyState.Dead)
            return;
        _health -= damage;

        ApllyDamageEvents?.Invoke(_health, _startHealth);

        SetAnimationTrigger(_applyDamageAnimation);
        _instance.CurrentState = EnemyState.TakeDamage;
        if (_health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        _instance.CurrentState = EnemyState.Dead;
        SetAnimationBool(_deadAnimation, true);
        if (!_scoreView)
            _scoreView = FindObjectOfType<ScoreView>();
        _scoreView.UpdateScore();
        StartCoroutine(Respawn());
    }
    private IEnumerator Respawn()
    {
        var position = transform.position;
        position.y += 1;
        Instantiate(_healthSpherePrefab, position, Quaternion.identity);
        yield return new WaitForSeconds(_respawnDelay);
        _health = ++_startHealth;
        transform.position = new Vector3(_distanceChecker.Target.transform.position.x + Random.Range(-_reswpawnRadius, _reswpawnRadius),
                                         _distanceChecker.Target.transform.position.y + 5, 
                                         _distanceChecker.Target.transform.position.z + Random.Range(-_reswpawnRadius, _reswpawnRadius));
        SetAnimationTrigger(_respawnAnimation);
        SetAnimationBool(_deadAnimation, false);
        _instance.CurrentState = EnemyState.Idle;
        ApllyDamageEvents?.Invoke(_health, _startHealth);
    }
}
