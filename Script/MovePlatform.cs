using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    public Vector3 TargetPos;
    private Vector3 CurrentPos, StartPos, temPos;
    void Start()
    {
        StartPos = transform.position;
        
    }
    void Update()
    {
        CurrentPos = transform.position;
        transform.position = Vector3.MoveTowards(CurrentPos, TargetPos, 3 * Time.deltaTime);
        if(transform.position == TargetPos)
        {
            temPos = TargetPos;
            TargetPos = StartPos;
            StartPos = temPos;
        }
        
    }
}
