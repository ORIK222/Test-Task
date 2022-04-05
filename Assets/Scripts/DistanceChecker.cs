using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField] private float _distanceToTargetForStalking;
    [SerializeField] private float _distanceForAttack;

    private Character _target;

    public Character Target => _target;
    private float _distance => Vector3.Distance(transform.position, _target.transform.position);

    private void Awake() => _target = FindObjectOfType<Character>();
    public bool CheckDistanceForStalking() => _distance <= _distanceToTargetForStalking;
    public bool CheckDistanceForAttack() => _distance <= _distanceForAttack;

}
