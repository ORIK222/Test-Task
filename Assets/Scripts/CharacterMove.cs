using UnityEngine;

public class CharacterMove : CharacterAbility
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private FollowCamera _followCamera;

    private const string _walkAnimation = "Walk";

    private void FixedUpdate() => Move();

    private void Move()
    {
        if (_currentState == CharacterState.Attack || _currentState == CharacterState.Dead)
            return;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + _keyInput, _speed * Time.deltaTime);
        if (_keyInput != Vector3.zero)
        {
            SetAnimationBool(_walkAnimation, true);
            Quaternion desiredRotation = Quaternion.LookRotation(_keyInput, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }
        else
            SetAnimationBool(_walkAnimation, false);
    }

}
