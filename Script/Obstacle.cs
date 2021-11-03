using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<DieEffect>().Dead(collision.transform.position);
            FindObjectOfType<AudioManager>().Play("DieSound");
            Destroy(collision.gameObject);
        }
    }
    
}
