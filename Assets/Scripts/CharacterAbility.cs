using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAbility : MonoBehaviour
{
    private Animator _animator;

    protected static CharacterState _currentState;
    protected Vector3 _keyInput;
    protected bool _leftMouseButtonClick => Input.GetMouseButtonDown(0);

    private void Awake() => _animator = GetComponent<Animator>();
    private void OnEnable() => _currentState = CharacterState.Idle;
    private void Update() => CheckInput();

    protected void SetAnimationBool(string parametr, bool value) => _animator.SetBool(parametr, value);
    protected void SetAnimationTrigger(string parametr) => _animator.SetTrigger(parametr);
    protected void ChangeState(CharacterState state) => _currentState = state;

    private void CheckInput()
    {
        if (_currentState == CharacterState.Dead)
            return;

        _keyInput.x = Input.GetAxis("Horizontal");
        _keyInput.z = Input.GetAxis("Vertical");
    }
}

public enum CharacterState
{
    Idle, 
    Walk, 
    Attack, 
    Dead
}

