using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _score.PointsChanged += OnPointsChanged;
    }

    private void OnDisable()
    {
        _score.PointsChanged -= OnPointsChanged;
    }

    private void OnPointsChanged(int points)
    {
        _scoreText.text = points.ToString();
    }
}
