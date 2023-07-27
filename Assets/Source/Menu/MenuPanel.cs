using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private SettingsPanel _settingsPanel;
    [SerializeField] private DifficultySettings _difficultySettings;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);
        _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        GameScene.Load(_difficultySettings.Difficulty);
    }

    private void OnSettingsButtonClicked()
    {
        _settingsPanel.gameObject.SetActive(true);
    }
}
