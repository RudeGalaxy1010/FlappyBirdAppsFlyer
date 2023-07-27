using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _homeButton;
    [SerializeField] private GameStarter _gameStarter;

    private void OnEnable()
    {
        _replayButton.onClick.AddListener(OnReplayButtonClicked);
        _homeButton.onClick.AddListener(OnHomeButtonClicked);
    }

    private void OnDisable()
    {
        _replayButton.onClick.RemoveListener(OnReplayButtonClicked);
        _homeButton.onClick.RemoveListener(OnHomeButtonClicked);
    }

    private void OnReplayButtonClicked()
    {
        GameScene.Load(_gameStarter.Difficulty);
    }

    private void OnHomeButtonClicked()
    {
        MenuScene.Load();
    }
}
