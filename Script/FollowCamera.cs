using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowCamera : MonoBehaviour
{
    private Transform Player;

    private float smoothspeed = 0.075f;


    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    private void FixedUpdate() {
        //if (!Player)
        //{
         //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
        transform.position = Vector3.Lerp(transform.position, Player.position + new Vector3(0, 0, -10), smoothspeed);
    }


}
