using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    private MainMenu Menu;

    public AudioMixer Mixer;

    public Text volumePercentage;

    public Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    public Slider slider;

    void Awake()
    {
        Mixer.SetFloat("volume", PlayerPrefs.GetFloat("volume", 0));
        slider.value = PlayerPrefs.GetFloat("volume", 0);

        Menu = FindObjectOfType<MainMenu>();

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width ||
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }
    public void Back()
    {
        Menu.SettingMenu.SetActive(false);
        Menu.MenuButton.SetActive(true);
        Menu.Title.SetActive(true);
        Menu.Platform.SetActive(true);
    }
    public void Volume(float volume)
    {
        Mixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        float percentage = 80 + volume;
        volumePercentage.text = percentage.ToString() + "%";
    }
    public void Setresolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void FullSceen(bool IsFullSceen)
    {
        Screen.fullScreen = IsFullSceen;
    }
}
