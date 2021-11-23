using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    public Text text;
    private void Start()
    {
        text.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }


}
