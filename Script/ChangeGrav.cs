using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGrav : MonoBehaviour
{
    //private Transform Camera;
    private bool TurnRight, TurnLeft, TurnUp, TurnDown;
    private bool canRoate = true;
    public int RotateSide = 0;
    public int RotateCount;
    public Text rotateText;
    private GameObject Camera;
    private Player player;
    public Animator CamShake;
    private float count;



    void Start() {
        Camera = GameObject.FindWithTag("MainCamera");
        player = GetComponent<Player>();
    }
    void Update()
    {
        Switch();
        rotateText.text = RotateCount.ToString();
    }
    private void Switch(){
        TurnRight = Input.GetKeyDown(KeyCode.RightArrow);
        TurnLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        TurnUp = Input.GetKeyDown(KeyCode.UpArrow);
        TurnDown = Input.GetKeyDown(KeyCode.DownArrow);
        if (TurnRight && canRoate && RotateCount > 0)
        {
            canRoate = false;
            RotateSide -= 1;
            StartCoroutine(SlowSpin(90, 0.3f));
            if (RotateSide < 0){
                RotateSide = 3;
                
            }
            
        }
        if (TurnLeft && canRoate && RotateCount > 0)
        {
            canRoate = false;
            RotateSide += 1;
            StartCoroutine(SlowSpin(90, -0.3f));
            if (RotateSide > 3){
                RotateSide = 0;
            }
            
        }
        if (TurnUp || TurnDown)
        {
            if(RotateCount > 0)
            {
                RotateCount -= 1;
                if (canRoate)
                {
                    canRoate = false;
                    RotateSide += 2;
                    StartCoroutine(SlowSpin(180, 0.3f));
                    if (RotateSide == 4)
                    {
                        RotateSide = 0;
                    }
                    else if (RotateSide == 5)
                    {
                        RotateSide = 1;
                    }
                
                }
            }
            
        }
        if (TurnRight || TurnLeft || TurnUp || TurnDown)
        {
            if(RotateCount > 0)
            {
                RotateCount -= 1;
            }
            switch (RotateSide)
            {
                case 0:
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case 1:
                    transform.eulerAngles = new Vector3(0, 0, 270);
                    break;
                case 2:
                    transform.eulerAngles = new Vector3(0, 0, 180);
                    break;
                case 3:
                    transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
            }
        }
        
        switch (RotateSide)
        {
            case 0:
                Physics2D.gravity = Vector2.down * 9.81f;
                break;
            case 1:
                Physics2D.gravity = Vector2.left * 9.81f;
                break;
            case 2:
                Physics2D.gravity = Vector2.up * 9.81f;
                break;
            case 3:
                Physics2D.gravity = Vector2.right * 9.81f;
                break;
        }
    }

    IEnumerator SlowSpin(int X, float rotationAmount)
    {
        CamShake.SetTrigger("Shake");
        count = 0;
        while (count <= X)
        {
            Camera.transform.Rotate(new Vector3(0, 0, rotationAmount));
            if (rotationAmount < 0)
            {
                count -= rotationAmount;
            }
            else
            {
                count += rotationAmount;
            }
            
            yield return new WaitForSeconds(0.000001f);
            
        }
        if (Camera.transform.rotation.eulerAngles.z < 91f && Camera.transform.rotation.eulerAngles.z > 89f)
        {
            Camera.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Camera.transform.rotation.eulerAngles.z < 181f && Camera.transform.rotation.eulerAngles.z > 179f)
        {
            Camera.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (Camera.transform.rotation.eulerAngles.z < 271f && Camera.transform.rotation.eulerAngles.z > 269f)
        {
            Camera.transform.eulerAngles = new Vector3(0, 0, 270);
        }
        else if (Camera.transform.rotation.eulerAngles.z < 1 && Camera.transform.rotation.eulerAngles.z > -1)
        {
            Camera.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        canRoate = true;
    }


}
