using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipesSpawner : Pauseable
{
    public event Action<PipeWall> PipeWallCreated;

    [SerializeField] private PipeWall _pipeWallPrefab;
    [SerializeField] private Transform _spawnPoint;

    private SpawnSettings _spawnSettings;
    private MoveSettings _moveSettings;
    private bool _isActive;
    private float _timer;

    public void Construct(SpawnSettings spawnSettings, MoveSettings moveSettings)
    {
        _spawnSettings = spawnSettings;
        _moveSettings = moveSettings;
        _isActive = true;
    }

    private void Update()
    {
        if (_isActive == false)
        {
            return;
        }

        _timer += Time.deltaTime;

        if (_timer >= _spawnSettings.SpawnTime)
        {
            _timer = 0;
            CreatePipes();
        }
    }

    private void CreatePipes()
    {
        PipeWall pipeWall = Instantiate(_pipeWallPrefab, _spawnPoint.position, Quaternion.identity);
        float windowSize = Random.Range(_spawnSettings.MinWindowSize, _spawnSettings.MaxWindowSize);
        pipeWall.Construct(windowSize, _moveSettings.Speed);
        PipeWallCreated?.Invoke(pipeWall);
    }

    public override void SetPause(bool isPause)
    {
        _isActive = !isPause;
    }
}
