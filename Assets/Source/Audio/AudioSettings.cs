using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private const string VolumeParameterName = "Volume";
    private const float MinVolume = -80f;
    private const float MaxVolume = 0f;

    public event Action<float> VolumeChanged;

    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private AudioMixer _audioMixer;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }

    public void Construct(float? volume = null)
    {
        _volumeSlider.minValue = MinVolume;
        _volumeSlider.maxValue = MaxVolume;
        _volumeSlider.value = volume == null ? MaxVolume : volume.Value;
    }

    private void OnVolumeChanged(float value)
    {
        _audioMixer.SetFloat(VolumeParameterName, value);
        VolumeChanged?.Invoke(value);
    }
}
