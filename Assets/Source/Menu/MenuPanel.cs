using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private SettingsPanel _settingsPanel;
    [SerializeField] private DifficultySettings _difficultySettings;

    private Difficulty _difficulty;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);
        _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        _difficultySettings.DifficultyChanged += OnDifficultyChanged;
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        _difficultySettings.DifficultyChanged -= OnDifficultyChanged;
    }

    private void OnPlayButtonClicked()
    {

    }

    private void OnSettingsButtonClicked()
    {
        _settingsPanel.gameObject.SetActive(true);
    }

    private void OnDifficultyChanged(Difficulty difficulty)
    {
        _difficulty = difficulty;
    }
}
