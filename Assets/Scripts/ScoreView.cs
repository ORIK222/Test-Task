using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;

    public int Score => _score;
    public void UpdateScore()
    {
        _scoreText.text = "Score: " + (++_score).ToString();
    }
}
