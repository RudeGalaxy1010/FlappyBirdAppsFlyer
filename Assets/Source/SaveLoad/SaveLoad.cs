using System;
using UnityEngine;

public class SaveLoad
{
    private const string SaveKay = "fbafsv";

    private AudioSettings _audioSettings;
    private DifficultySettings _difficultySettings;

    private SaveData _saveData;

    public SaveLoad(AudioSettings audioSettings, DifficultySettings difficultySettings)
    {
        _audioSettings = audioSettings;
        _difficultySettings = difficultySettings;

        _audioSettings.VolumeChanged += OnVolumeChanged;
        _difficultySettings.DifficultyIndexChanged += OnDifficultyChanged;
    }

    ~SaveLoad()
    {
        _audioSettings.VolumeChanged -= OnVolumeChanged;
    }

    public SaveData Load()
    {
        string data = PlayerPrefs.GetString(SaveKay, string.Empty);
        SaveData saveData = new SaveData();

        if (data != string.Empty)
        {
            saveData = JsonUtility.FromJson<SaveData>(data);
        }

        _saveData = saveData;
        return saveData;
    }

    public void Save(SaveData saveData)
    {
        string data = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SaveKay, data);
    }

    private void OnVolumeChanged(float value)
    {
        _saveData.Volume = value;
        Save(_saveData);
    }

    private void OnDifficultyChanged(int difficulty)
    {
        _saveData.Difficulty = difficulty;
        Save(_saveData);
    }
}
