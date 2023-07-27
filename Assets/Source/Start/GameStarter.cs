using IJunior.TypedScenes;
using UnityEngine;

public class GameStarter : MonoBehaviour, ISceneLoadHandler<Difficulty>
{
    [SerializeField] private PipesSpawner _pipesSpawner;

    private Difficulty _difficulty;

    public void OnSceneLoaded(Difficulty difficulty)
    {
        _difficulty = difficulty;
    }

    private void Start()
    {
        _pipesSpawner.Construct(_difficulty.SpawnSettings, _difficulty.MoveSettings);
    }

    public Difficulty Difficulty => _difficulty;
}
