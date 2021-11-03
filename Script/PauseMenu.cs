using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject JumpBar;
    public GameObject MiniMap;
    public GameObject Button;
    public GameObject PauseMenuUI;
    public GameObject CrossFade;
    public GameObject setting;

    public AudioSource AudioSource;
    public AudioClip highlightSound;
    public AudioClip ClickSound;

    public Animator MenuAnim;
    private void Start()
    {
        StartCoroutine(Unactive());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        StartCoroutine(resume(0.5f));
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator resume(float time)
    {
        setting.SetActive(false);
        PauseMenuUI.SetActive(true);
        JumpBar.SetActive(true);
        MiniMap.SetActive(true);
        Button.SetActive(true);
        Time.timeScale = 1;
        GameIsPaused = false;
        MenuAnim.SetBool("Paused", GameIsPaused);
        yield return new WaitForSecondsRealtime(time);
        PauseMenuUI.SetActive(false);
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        JumpBar.SetActive(false);
        MiniMap.SetActive(false);
        Button.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
        MenuAnim.SetBool("Paused", GameIsPaused);
    }
    public void Setting()
    {
        StartCoroutine(LoadSetting());
    }
    private IEnumerator LoadSetting()
    {
        MenuAnim.SetBool("Paused", false);
        setting.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        PauseMenuUI.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        CrossFade.SetActive(true);
        CrossFade.GetComponent<Animator>().SetTrigger("Start");
        StartCoroutine(loadMenu(1f));
    }
    private IEnumerator loadMenu(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        PauseMenuUI.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
    private IEnumerator Unactive()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        CrossFade.SetActive(false);
    }
    public void HighlightSound()
    {
        AudioSource.PlayOneShot(highlightSound);
    }
    public void Clicksound()
    {
        AudioSource.PlayOneShot(ClickSound);
    }
    public void Back()
    {
        PauseMenuUI.SetActive(true);
        MenuAnim.SetBool("Paused", true);
        setting.GetComponent<Animator>().SetTrigger("Closs");
        StartCoroutine(BackToMenu());
    }
    private IEnumerator BackToMenu()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        setting.SetActive(false);
        
    }
}
