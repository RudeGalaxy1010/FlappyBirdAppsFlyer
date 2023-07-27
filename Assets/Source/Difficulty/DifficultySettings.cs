using System;
using TMPro;
using UnityEngine;

public class DifficultySettings : MonoBehaviour
{
    public event Action<int> DifficultyIndexChanged;

    [SerializeField] private TMP_Dropdown _difficultyDropdown;
    [SerializeField] private Difficulty[] _difficulties;

    private int _difficultyIndex;

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

        _difficultyIndex = difficulty == null ? 0 : difficulty.Value;
        _difficultyDropdown.value = _difficultyIndex;
    }

    public Difficulty Difficulty => _difficulties[_difficultyIndex];

    private void OnDifficultyChanged(int value)
    {
        _difficultyIndex = value;
        DifficultyIndexChanged?.Invoke(_difficultyIndex);
    }
}
