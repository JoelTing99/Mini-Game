using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMapCamera : MonoBehaviour
{
    private Transform Player;
    public GameObject BigMap;
    private Camera Cam;
    public float MidX, MidY;
    public float CamSize, CamNormalSize;

    private float smoothspeed = 0.075f;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        Cam = GetComponent<Camera>();
    }
    private void Update()
    {
        if (!Player)
        {
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }
        if (Input.GetKey(KeyCode.M) || Input.GetKey(KeyCode.Tab))
        {
            Cam.orthographicSize = CamSize;
            BigMap.SetActive(true);
            transform.position = new Vector3(MidX, MidY, -10);
        }
        else
        {
            Cam.orthographicSize = CamNormalSize;
            BigMap.SetActive(false);
            transform.position = Vector3.Lerp(transform.position, Player.position + new Vector3(0, 0, -10), smoothspeed);
        }
    }
}
