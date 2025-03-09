using System;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _scoreView;

    private Score _score;

    private void OnDestroy()
    {
        _score.ScoreChanged -= OnScoreChanged;
    }

    public void Init(Score score)
    {
        _score = score != null ? score : throw new ArgumentNullException(nameof(score));
        _score.ScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int value)
    {
        foreach(var view in _scoreView)
        {
            view.text = value.ToString();
        }
    }
}
