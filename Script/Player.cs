using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
  
    private Rigidbody2D rb;
    public GameObject LandEffect;
    private Animator anim;
    public Transform GroundChack;
    public LayerMask WhatIsGround;
    private ChangeGrav Side;
    private Vector3 animDirationRight, animDirationLeft;
    public AudioSource JumpSound;
    private JumpBar JumpBar;


    private int dirationX, dirationY;
    private int Effectcount;
    private int SpaceCount;


    public float Speed; 
    public float JumpForce;
    private float JumpTime = 0.35f;

    private bool moveright, moveleft;
    private bool Isgrounded;
    private bool IsJumping = false;

    void Start()
    {
        Side = GetComponent<ChangeGrav>();
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
        JumpBar = FindObjectOfType<JumpBar>();
        JumpBar.SetMaxCharge(JumpTime);
    }

    private void FixedUpdate() {
        diration();
        MoveMent();
        Flip();
        Isgrounded = Physics2D.OverlapCircle(GroundChack.position, 0.3f, WhatIsGround);
        if (Isgrounded){
            IsJumping = false;
            
            if (JumpTime > 0)
            {
                JumpTime -= Time.deltaTime;
            }
            if(Effectcount < 1)
            {
                Instantiate(LandEffect, GroundChack.position, Quaternion.Euler(180, 0, 0));
                Effectcount++;
            }
            
        }else{
            IsJumping = true;
            Effectcount = 0;
        }

        if (IsJumping)
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }
        JumpBar.SetJumpCharge(JumpTime);
    }
    private void Update() {
        Jump();
        if (Input.GetKeyDown(KeyCode.Space) && Isgrounded)
        {
            JumpSound.Play();
        }
    }
    
    private void diration(){
        switch (Side.RotateSide)
        {
            case 0:
                dirationX = 1;
                dirationY = 0;
                animDirationRight = new Vector3(0, 0, 0);
                animDirationLeft = new Vector3(0, 180, 0);
                
                break;
            case 1:
                dirationX = 0;
                dirationY = -1;
                animDirationRight = new Vector3(0, 0, 270);
                animDirationLeft = new Vector3(180, 0, 270);
                
                break;
            case 2:
                dirationX = -1;
                dirationY = 0;
                animDirationRight = new Vector3(0, 0, 180);
                animDirationLeft = new Vector3(0, 180, 180);
                
                break;
            case 3:
                dirationX = 0;
                dirationY = 1;
                animDirationRight = new Vector3(0, 0, 90);
                animDirationLeft = new Vector3(180, 0, 90);
                break;
        }
    }

    private void MoveMent() {
        moveright = Input.GetKey(KeyCode.D);
        moveleft = Input.GetKey(KeyCode.A);
        if (Speed < 7)
        {
            Speed += 30 * Time.deltaTime;
        }

        if (moveright) {
            
            transform.position = transform.position + new Vector3(Speed * Time.deltaTime * dirationX, Speed * Time.deltaTime * dirationY, 0);
        } else if (moveleft) {
            
            transform.position = transform.position + new Vector3(-1 * Speed * Time.deltaTime * dirationX, -1 * Speed * Time.deltaTime * dirationY, 0);
        }
        else
        {
            Speed = 0;
        }
    }

    private void Flip(){
        if(moveleft){
            transform.eulerAngles = animDirationLeft;
        }
        if (moveright){
            transform.eulerAngles = animDirationRight;
        }
    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && Isgrounded)
        {
            
            anim.SetTrigger("TakeOf");
            switch (Side.RotateSide){
            case 0:
                rb.velocity = Vector2.up * JumpForce;
                break;
            case 1:
                rb.velocity = Vector2.right * JumpForce;
                break;
            case 2:
                rb.velocity = Vector2.down * JumpForce;
                break;
            case 3:
                rb.velocity = Vector2.left * JumpForce;
                break;
            }
            SpaceCount = 0;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpaceCount++;
        }
        if (Input.GetKey(KeyCode.Space) && JumpTime < 0.35 && SpaceCount < 1)
        {
        JumpTime += Time.deltaTime;
        switch (Side.RotateSide)
            {
            case 0:
                rb.velocity = Vector2.up * JumpForce;
                break;
            case 1:
                rb.velocity = Vector2.right * JumpForce;
                break;
            case 2:
                rb.velocity = Vector2.down * JumpForce;
                break;
            case 3:
                rb.velocity = Vector2.left * JumpForce;
                break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }
    
}
