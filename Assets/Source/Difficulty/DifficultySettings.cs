using System;
using TMPro;
using UnityEngine;

public class DifficultySettings : MonoBehaviour
{
    public event Action<int> DifficultyIndexChanged;
    public event Action<Difficulty> DifficultyChanged;

    [SerializeField] private TMP_Dropdown _difficultyDropdown;
    [SerializeField] private Difficulty[] _difficulties;

    private void OnEnable()
    {
        _difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);
    }

    private void OnDisable()
    {
        _difficultyDropdown.onValueChanged.RemoveListener(OnDifficultyChanged);
    }

    public void Construct(int? difficulty = null)
    {
        _difficultyDropdown.options.Clear();

        for (int i = 0; i < _difficulties.Length; i++)
        {
            _difficultyDropdown.options.Add(new TMP_Dropdown.OptionData(_difficulties[i].name));
        }

        // TODO: check if index set
        _difficultyDropdown.value = difficulty == null ? 0 : difficulty.Value;
    }

    private void OnDifficultyChanged(int value)
    {
        DifficultyIndexChanged?.Invoke(value);
        DifficultyChanged?.Invoke(_difficulties[value]);
    }
}
