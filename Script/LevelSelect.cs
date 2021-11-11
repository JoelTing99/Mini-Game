using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    private int level;
    public Animator CrossFade;
    public MainMenu Menu;
    public GameObject Level;
    public GameObject[] Completed;
    private void Start()
    {
        for (int i = 1; i < 31; i++)
        {
            if (PlayerPrefs.GetString("Completed").Contains($"{i}"))
            {
                Completed[i - 1].SetActive(true);
            }
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }
    public void Choose()
    {
        level = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        StartCoroutine(Loading());
    }
    IEnumerator Loading()
    {
        CrossFade.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(level);
    }
    public void Back()
    {
        Menu.LevelSelectMenu.SetActive(false);
        Menu.MenuButton.SetActive(true);
        Menu.Title.SetActive(true);
        Menu.Platform.SetActive(true);
    }
    public void Resets ()
    {
        PlayerPrefs.DeleteAll();
        for (int i = 1; i < 11; i++)
        {
            Completed[i - 1].SetActive(false);
        }
    }
    public void Scroll(float value)
    {
        Level.transform.localPosition = new Vector3(-value * 1000f, 0, 0);
    }
}
