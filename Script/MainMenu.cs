using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject Title;
    public GameObject MenuButton;
    public GameObject SettingMenu;
    public GameObject LevelSelectMenu;
    public GameObject Platform;
    public GameObject CrossFade;
    public AudioSource AudioSource;
    public AudioClip highlightSound;
    public AudioClip ClickSound;
    public AudioMixer Mixer;

    private void Awake()
    {
        SettingMenu.SetActive(true);
    }
    private void Start()
    {
        StartCoroutine(Unactive());
        StartCoroutine(Active());
        Mixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        SettingMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        LevelSelectMenu.SetActive(true);
        MenuButton.SetActive(false);
        Title.SetActive(false);
        Platform.SetActive(false);
    }
    private IEnumerator Unactive()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        CrossFade.SetActive(false);
    }
    private IEnumerator Active()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Platform.SetActive(true);
    }
    public void Setting()
    {
        SettingMenu.SetActive(true);
        MenuButton.SetActive(false);
        Title.SetActive(false);
        Platform.SetActive(false);
    }
    public void HighlightSound()
    {
        AudioSource.PlayOneShot(highlightSound);
    }
    public void Clicksound()
    {
        AudioSource.PlayOneShot(ClickSound);
    }
}
