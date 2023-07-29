using IJunior.TypedScenes;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private SettingsPanel _settingsPanel;
    [SerializeField] private DifficultySettings _difficultySettings;
    [SerializeField] private AppsFlyerObjectScript _appsflyerObjectScript;
    [SerializeField] private TMP_Text _conversionDataText;

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

    private void Start()
    {
        _playButton.interactable = false;
        StartCoroutine(WaitForLoadAndEnablePlayButton());
    }

    private IEnumerator WaitForLoadAndEnablePlayButton()
    {
        _conversionDataText.text += "\nLoaded: " + _appsflyerObjectScript.Loaded.ToString();
        yield return new WaitUntil(() => _appsflyerObjectScript.Loaded == true);
        _playButton.interactable = true;
        _conversionDataText.text = _appsflyerObjectScript.ConversionData;
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
