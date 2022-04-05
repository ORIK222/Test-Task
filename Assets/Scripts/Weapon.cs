using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _distanceForAttack = 3f;
    
    private float _attackForce;
    private Enemy _currentTarget;

    public float AttackForce
    {
        get => _attackForce;
        set
        {
            if (value < 0)
                _attackForce = 0;
            else
                _attackForce = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out var enemy))
            _currentTarget = enemy;
       
    }

    public void Attack()
    {
        if(_currentTarget)
            if(Vector3.Distance(transform.position, _currentTarget.transform.position) < _distanceForAttack)
                _currentTarget.TakeDamage(_attackForce);
    }
}
