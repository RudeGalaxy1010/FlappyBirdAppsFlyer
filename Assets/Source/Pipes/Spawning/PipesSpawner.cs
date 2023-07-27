using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
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
        Debug.Log("Pipes created");
    }
}
