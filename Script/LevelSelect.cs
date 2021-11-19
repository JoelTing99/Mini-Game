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
    public Slider Slider;
    public GameObject Level;
    public GameObject Levelselect_Text;
    public GameObject[] Completed;
    private void Start()
    {
        for (int i = 1; i < Completed.Length + 1; i++)
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
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Slider.value -= Input.GetAxis("Mouse ScrollWheel") * 1.1f;
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
        Level.transform.localPosition = new Vector3(0, value * 100f, 0);
        if(value >= 0.6f)
        {
            Levelselect_Text.SetActive(false);
        }else
        {
            Levelselect_Text.SetActive(true);
        }
    }
}
