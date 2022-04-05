using UnityEngine;

[RequireComponent(typeof(DistanceChecker))]
[RequireComponent(typeof(Animator))]
public class EnemyAbility : MonoBehaviour
{
    protected DistanceChecker _distanceChecker;
    protected EnemyAbility _instance;

    private Animator _animator;
    private EnemyState _currentState;
  
    public EnemyState CurrentState { get => _currentState; set { _currentState = value; } }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _distanceChecker = GetComponent<DistanceChecker>();
        _instance = GetComponent<EnemyAbility>();
    }
    protected void SetAnimationBool(string parametr, bool value) => _animator.SetBool(parametr, value);
    protected void SetAnimationTrigger(string parametr) => _animator.SetTrigger(parametr);
}

public enum EnemyState
{
    Idle, 
    Walk,
    Attack, 
    TakeDamage, 
    Dead
}
