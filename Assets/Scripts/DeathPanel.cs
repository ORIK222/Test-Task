using UnityEngine;
using TMPro;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnEnable() => _scoreText.text = "Score: " + _scoreView.Score.ToString();
}
