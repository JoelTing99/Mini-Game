using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class click : MonoBehaviour, IPointerClickHandler
{
    public GameObject Panel;
    public Text Count;
    private bool isOpened = false; 
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            if (isOpened)
            {
                Panel.SetActive(false);
                isOpened = false;
            }
            else
            {
                Panel.SetActive(true);
                Count.text = PlayerPrefs.GetInt($"Deadcount{name}", 0).ToString();
                isOpened = true;
            }


        }

    }
    
}
