using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerVolumeControl : MonoBehaviour
{
    [Header("Audio Mixer Settings")]
    public AudioMixer audioMixer;

    [Header("Sliders")]
    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Start()
    {
        // Set initial slider values based on the current mixer settings
        if (audioMixer != null)
        {
            float masterVolume, bgmVolume, sfxVolume;
            audioMixer.GetFloat("VolumeMaster", out masterVolume);
            audioMixer.GetFloat("VolumeBGM", out bgmVolume);
            audioMixer.GetFloat("VolumeSFX", out sfxVolume);

            //masterVolumeSlider.value = Mathf.Pow(10, masterVolume / 20); // Convert dB to linear
            masterVolumeSlider.value = masterVolume;
            //bgmVolumeSlider.value = Mathf.Pow(10, bgmVolume / 20);
            bgmVolumeSlider.value = bgmVolume;
            //sfxVolumeSlider.value = Mathf.Pow(10, sfxVolume / 20);
            sfxVolumeSlider.value = sfxVolume;
        }

        // Add listener for slider changes
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    // Methods to update audio mixer values based on slider input
    public void SetMasterVolume(float value)
    {
        //float volume = Mathf.Log10(value) * 20; // Convert linear to dB
        audioMixer.SetFloat("VolumeMaster", value);
    }

    public void SetBGMVolume(float value)
    {
        //float volume = Mathf.Log10(value) * 20; // Convert linear to dB
        audioMixer.SetFloat("VolumeBGM", value);
    }

    public void SetSFXVolume(float value)
    {
        //float volume = Mathf.Log10(value) * 20; // Convert linear to dB
        audioMixer.SetFloat("VolumeSFX", value);
    }

    private void OnDestroy()
    {
        // Remove listeners to avoid memory leaks
        masterVolumeSlider.onValueChanged.RemoveListener(SetMasterVolume);
        bgmVolumeSlider.onValueChanged.RemoveListener(SetBGMVolume);
        sfxVolumeSlider.onValueChanged.RemoveListener(SetSFXVolume);
    }
}
