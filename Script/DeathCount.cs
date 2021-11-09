using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public GameObject Dead;
    private int Deadcount;
    private int Limit;

    void Start()
    {
        Limit = 0;
        Deadcount = PlayerPrefs.GetInt($"Deadcount{SceneManager.GetActiveScene().buildIndex}", 0);
    }

    void Update()
    {
        if (!GameObject.FindWithTag("Player") && Limit < 1)
        {   

            Dead.SetActive(true);
            Deadcount++;
            Limit++;
            PlayerPrefs.SetInt($"Deadcount{SceneManager.GetActiveScene().buildIndex}", Deadcount);
            
        }
        if (Input.GetKeyDown(KeyCode.R) && !GameObject.FindWithTag("Player"))
        {
            FindObjectOfType<PauseMenu>().Restart();
        }
    }
}
