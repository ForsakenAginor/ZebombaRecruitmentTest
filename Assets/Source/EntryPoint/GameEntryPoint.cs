using Assets.Scripts.General;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _joint;
    [SerializeField] private BallLauncher _launcher;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BallPool _pool;
    [SerializeField] private GameGridCreator _gridCreator;
    [SerializeField] private SwitchableElement _loseScreen;
    [SerializeField] private BallScoreConfiguration _scoreConfiguration;
    [SerializeField] private ScoreView _scoreView;

    private void Start()
    {
        _pool.Init();
        _ = new BallSpawner(_joint, _launcher, _spawnPoint.position, _pool);
        _gridCreator.Init();
        GridMatchFinder gridManager = new GridMatchFinder(_gridCreator.Grid);
        ProgressMonitor progressMonitor = new ProgressMonitor(gridManager, _loseScreen);
        Score score = new Score(gridManager, _scoreConfiguration);
        _scoreView.Init(score);
        SceneChangerSingleton.Instance.FadeOut();
    }
}
