using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    private Animator Transition;
    private GameObject CrossFade;
    private string CompletedLevel;
    private void Awake()
    {
        Transition = GameObject.FindWithTag("CrossFade").GetComponent<Animator>();
        CrossFade = GameObject.FindWithTag("CrossFade");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CrossFade.SetActive(true);
            SaveCompletedLevel();
            LoadNextLevel();
            Time.timeScale = 0;
        }
    }
    private void SaveCompletedLevel()
    {
        CompletedLevel = PlayerPrefs.GetString("Completed");
        CompletedLevel += SceneManager.GetActiveScene().buildIndex.ToString();
        PlayerPrefs.SetString("Completed", CompletedLevel);
    }
    private void LoadNextLevel()
    {
        FindObjectOfType<AudioManager>().Play("EndSound");
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            StartCoroutine(LoadLevel(0));
        }
        else
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
    IEnumerator LoadLevel(int LevelIndex)
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        SceneManager.LoadScene(LevelIndex);
        
    }
}
