using System.Collections.Generic;
using UnityEngine;

public class GameStopper : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private PipesSpawner _pipesSpawner;
    [SerializeField] private Pauseable[] _staticPauseables;
    [SerializeField] private EndGamePanel _endPanel;

    private List<Pauseable> _dynamicPauseables = new List<Pauseable>();

    private void OnEnable()
    {
        _playerHealth.Died += OnPlayerDied;
        _pipesSpawner.PipeWallCreated += OnPipeWallCreated;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= OnPlayerDied;
        _pipesSpawner.PipeWallCreated -= OnPipeWallCreated;
    }

    private void OnPipeWallCreated(PipeWall pipeWall)
    {
        if (pipeWall.TryGetComponent(out HorizontalMove move) == false)
        {
            return;
        }

        for (int i = 0; i < _dynamicPauseables.Count; i++)
        {
            if (_dynamicPauseables[i] == null)
            {
                _dynamicPauseables.RemoveAt(i);
                i--;
            }
        }

        _dynamicPauseables.Add(move);
    }

    private void OnPlayerDied()
    {
        var pauseables = new List<Pauseable>();
        pauseables.AddRange(_staticPauseables);
        pauseables.AddRange(_dynamicPauseables);

        for (int i = 0; i < pauseables.Count; i++)
        {
            pauseables[i].SetPause(true);
        }

        _endPanel.gameObject.SetActive(true);
    }
}
