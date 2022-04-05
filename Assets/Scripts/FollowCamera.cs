using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public bool GameStart;

    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed = 0.2f;
    [SerializeField] private float _rotationSpeed;
    
    private Vector3 _currentOffset;
    private bool _rotateAroundPlayer => Input.GetMouseButton(1);
    

    private void Start()
    {
        _currentOffset = _offset;
    }
    private void FixedUpdate()
    {
        if (GameStart == false)
            return;

        if (_rotateAroundPlayer)
        {
            Quaternion angle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _rotationSpeed, Vector3.up);
            _currentOffset = angle * _currentOffset;
        }
        else
            _currentOffset = Vector3.Lerp(_currentOffset,_offset, _speed/4 * Time.deltaTime);

        Vector3 targetPosition = _target.position + _currentOffset;

        transform.position = Vector3.Slerp(transform.position, targetPosition, _speed);
        transform.LookAt(_target);
    }
}

