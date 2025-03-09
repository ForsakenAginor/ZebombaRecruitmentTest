﻿using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _joint;
    [SerializeField] private BallLauncher _launcher;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BallPool _pool;

    private void Start()
    {
        _pool.Init();
        _ = new BallSpawner(_joint, _launcher, _spawnPoint.position, _pool);
    }
}
