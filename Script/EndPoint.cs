using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public Animator Transition;
    public GameObject CrossFade;
    private string CompletedLevel;
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
        if(SceneManager.GetActiveScene().buildIndex == 10)
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
