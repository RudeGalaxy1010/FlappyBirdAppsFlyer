using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Difficulty[] _difficulties;
    [SerializeField] private PipesSpawner _pipesSpawner;

    private int _difficultyIndex;

    private void Start()
    {
        Difficulty difficulty = _difficulties[_difficultyIndex];
        _pipesSpawner.Construct(difficulty.SpawnSettings, difficulty.MoveSettings);
    }
}
