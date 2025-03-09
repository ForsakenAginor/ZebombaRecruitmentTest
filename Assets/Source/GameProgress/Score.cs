using System;

public class Score
{
    private readonly GridMatchFinder _matchFinder;
    private readonly IScoreByColorGetter _configuration;
    private int _score;

    public Score(GridMatchFinder matchFinder, IScoreByColorGetter configuration)
    {
        _matchFinder = matchFinder != null ? matchFinder : throw new ArgumentNullException(nameof(matchFinder));
        _configuration = configuration != null ? configuration : throw new ArgumentNullException(nameof(configuration));

        _matchFinder.BallRemoved += OnBallRemoved;
    }

    ~Score()
    {
        _matchFinder.BallRemoved -= OnBallRemoved;
    }

    public event Action<int> ScoreChanged;

    private void OnBallRemoved(BallColor color)
    {
        _score += _configuration.GetScoreBy(color);
        ScoreChanged?.Invoke(_score);
    }
}
