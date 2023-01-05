using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Text volumeTextUI = null;
    [SerializeField] private Slider sensSlider = null;
    [SerializeField] private Text sensTextUI = null;

    private void Start()
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = (volume*100).ToString("0");
        Debug.Log(volume);
    }

    public void SensSlider(float sens)
    {
        sensTextUI.text = sens.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("GameVolume", volumeValue);
        Debug.Log("volume Saved!");
        LoadValues();
    }

    public void SaveSensButton()
    {
        float sensValue = sensSlider.value;
        PlayerPrefs.SetFloat("MouseSensitivity", sensValue);
        Debug.Log("Sens Saved!");
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("GameVolume");
        volumeSlider.value = volumeValue;
        float sensValue = PlayerPrefs.GetFloat("MouseSensitivity");
        sensSlider.value = sensValue;
    }

    public void GoToMainMenu()
    {
        // Make sure MainMenu is the 1st scene in build setrtings and has index 0
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene(0);
    }
}
