using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public LineRenderer Line;
    public GameObject LaserEffect;
    public AudioSource Sound;
    public float Times, StartDelay;
    public Vector3 MoveTo;
    private Vector3 BackTo;
    private RaycastHit2D hitInfo;
    

    void Start()
    {
        BackTo = transform.position;
        StartCoroutine(Switch(Times));
        StartCoroutine(laeserEffect());
    }

    void Update()
    {
        
        hitInfo = Physics2D.Raycast(transform.position, -transform.right, 50);
        if(hitInfo.collider != null)
        {
            Line.SetPosition(1, hitInfo.point);
            if (hitInfo.collider.CompareTag("Player"))
            {
                //Destroy(hitInfo.collider.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        Line.SetPosition(0, transform.position);
    }
    IEnumerator Switch(float time)
    {
        yield return new WaitForSeconds(StartDelay);
        while (true)
        {
            while(transform.position != MoveTo)
            {
                transform.position = Vector3.MoveTowards(transform.position, MoveTo, 5f * Time.deltaTime);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(time*2);
            while (transform.position != BackTo)
            {
                transform.position = Vector3.MoveTowards(transform.position, BackTo, 5f * Time.deltaTime);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(time);
        }
        
    }
    IEnumerator laeserEffect()
    {
        while (true)
        {
            if (transform.position == MoveTo)
            {
                Instantiate(LaserEffect, hitInfo.point, Quaternion.identity);
                Sound.Play();
                yield return new WaitForSeconds(1f);
                Sound.Stop();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
