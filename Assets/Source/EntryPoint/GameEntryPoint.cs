using Assets.Scripts.General;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _joint;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BallPool _pool;
    [SerializeField] private GameGridCreator _gridCreator;
    [SerializeField] private SwitchableElement _loseScreen;
    [SerializeField] private BallScoreConfiguration _scoreConfiguration;
    [SerializeField] private ScoreView _scoreView;

    PlayerInput _input;

    private void Start()
    {
        _pool.Init();
        _input = new PlayerInput();
        BallLauncher launcher = new BallLauncher(_input, _joint);
        _ = new BallSpawner(_joint, launcher, _spawnPoint.position, _pool);
        _gridCreator.Init();
        GridMatchFinder gridManager = new GridMatchFinder(_gridCreator.Grid);
        ProgressMonitor progressMonitor = new ProgressMonitor(gridManager, _loseScreen);
        Score score = new Score(gridManager, _scoreConfiguration);
        _scoreView.Init(score);
        SceneChangerSingleton.Instance.FadeOut();
    }

    private void OnDestroy()
    {
        _input.Destroy();
    }
}
