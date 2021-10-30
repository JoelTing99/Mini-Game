using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Generate : MonoBehaviour
{
    public GameObject gameOject;
    public GameObject Menu;
    public AudioSource audioSource;
    public AudioClip clickSound;
    private Camera cam;
    private Vector3 mousePos;
    private bool canGenerate;
    private int Count;
    
    private void Start()
    {
        cam = GetComponent<Camera>();
        Count = 0;
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 10;
        if (Menu.activeSelf)
        {
            if(mousePos.x < -3 && mousePos.y < 1)
            {
                canGenerate = false;
            }
            else
            {
                canGenerate = true;
            }
            if (Input.GetMouseButtonDown(0) && canGenerate && Count < 25)
            {
                Instantiate(gameOject, mousePos, Quaternion.identity);
                audioSource.PlayOneShot(clickSound);
                Count++;
            }
        }

        
    }
    
    
}
