using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowCamera : MonoBehaviour
{
    private Transform Player;
    private float smoothspeed = 0.1f;


    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    private void FixedUpdate() {
        if (!Player)
        {
            return;
        }
        if(Vector2.Distance(Player.position, transform.position) >= 3)
        {
            smoothspeed = 0.2f;
        }else
        {
            smoothspeed = 0.1f;
        }
        transform.position = Vector3.Lerp(transform.position, Player.position + new Vector3(0, 0, -10), smoothspeed);
    }


}
