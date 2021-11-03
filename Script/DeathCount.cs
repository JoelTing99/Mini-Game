using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public Text Count;
    public GameObject Dead;
    private int Deadcount;
    private int Limit;

    void Start()
    {
        Limit = 0;
        Deadcount = PlayerPrefs.GetInt("Deadcount", 0);
    }

    void Update()
    {
        Count.text = Deadcount.ToString();
        if (!GameObject.FindWithTag("Player") && Limit < 1)
        {   

            Dead.SetActive(true);
            Deadcount++;
            Limit++;
            PlayerPrefs.SetInt("Deadcount", Deadcount);
            
        }
    }
}
