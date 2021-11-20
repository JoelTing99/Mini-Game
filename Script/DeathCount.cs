using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public GameObject Dead;
    [HideInInspector]
    public int Deadcount;

    void Start()
    {
        Deadcount = PlayerPrefs.GetInt($"Deadcount{SceneManager.GetActiveScene().buildIndex}", 0);
    }

    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt($"Deadcount{SceneManager.GetActiveScene().buildIndex}"));
        if (!GameObject.FindWithTag("Player"))
        {   
            Dead.SetActive(true); 
        }
        if (Input.GetKeyDown(KeyCode.R) && !GameObject.FindWithTag("Player"))
        {
            FindObjectOfType<PauseMenu>().Restart();
            PlayerPrefs.SetInt($"Deadcount{SceneManager.GetActiveScene().buildIndex}", Deadcount);
        }
    }
}
