using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieEffect : MonoBehaviour
{
    public GameObject dieEffect;
    private Transform Player;
    
    void Start()
    { 
        if (!Player)
        {
            return;
        }
        DontDestroyOnLoad(gameObject);
        Player = GameObject.FindWithTag("Player").transform;
    }

    public void Dead(Vector3 Pos)
    {
        Instantiate(dieEffect, Pos, Quaternion.identity);
    }
}
