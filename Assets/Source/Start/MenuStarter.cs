using UnityEngine;
using AppsFlyerSDK;

public class MenuStarter : MonoBehaviour
{
    [SerializeField] private AudioSettings _audioSettings;
    [SerializeField] private DifficultySettings _difficultySettings;

    private void Start()
    {
        SaveLoad saveLoad = new SaveLoad(_audioSettings, _difficultySettings);
        SaveData saveData = saveLoad.Load();

        _audioSettings.Construct(saveData.Volume);
        _difficultySettings.Construct(saveData.Difficulty);
    }
}
