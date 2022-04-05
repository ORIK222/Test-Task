using UnityEngine;

public class HealthPanel : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private HealthBar _healthBar;

    private void OnEnable() => _player.UpdateHealthEvent += UpdateHealthBar;
    private void OnDisable() => _player.UpdateHealthEvent -= UpdateHealthBar;
    private void UpdateHealthBar(float current, float max) => _healthBar.SetHealthBarValue(current, max);
}
