using UnityEngine;

public class HealthSphere : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Character>(out var player))
        {
            player.BoostHealth();
            Destroy(gameObject);
        }
    }
}
