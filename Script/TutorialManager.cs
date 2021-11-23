using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] Popups;
    private int PopupIndex;
    private int currentLevel;
    private Transform player;
    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        for (int i = 0; i < Popups.Length; i++)
        {
            if(PopupIndex == i)
            {
                Popups[i].SetActive(true);
            }else
            {
                Popups[i].SetActive(false);
            }
        }

        if (currentLevel == 1)
        {
            if (PopupIndex == 0 && player.position.x >= -4)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    PopupIndex++;
                }
            }
            else if (PopupIndex == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    PopupIndex++;
                }
            }
            else if (PopupIndex == 2)
            {
                if (Input.anyKeyDown && player.position.y >= -4)
                {
                    PopupIndex++;
                }
            }
        }
        else if (currentLevel == 4)
        {
            if (PopupIndex == 0 && PopupIndex <= Popups.Length)
            {
                if (Input.GetKey(KeyCode.Tab))
                {
                    PopupIndex++;
                }
            }
            else if (PopupIndex == 1 && player.position.x <= 0.5)
            {
                if (Input.anyKey)
                {
                    PopupIndex++;
                }
            }
            else if (PopupIndex == 2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    PopupIndex++;
                }
            }
        }
        else if (currentLevel == 6 || currentLevel == 14 || currentLevel == 17)
        {
            if (PopupIndex == 0 && PopupIndex <= Popups.Length)
            {
                if (Input.anyKey)
                {
                    PopupIndex++;
                }
            }
        }
        else if(currentLevel == 9)
        {
            if (PopupIndex == 0 && PopupIndex <= Popups.Length)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    PopupIndex++;
                }
            }
        }

    }
}
