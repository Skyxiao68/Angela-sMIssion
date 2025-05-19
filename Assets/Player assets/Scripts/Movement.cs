//2D Top Down Movement UNITY Tutorial
//BmO
// Accessed : 15 March 2025
// Code Version : 5
//https://youtu.be/u8tot-X_RBI?si=ZbpWg1TD81Oaciuy

//How To Do W A S D Movement In Unity 2D
//MileOnAir
// Accessed : 16 March 2025
// Code Version 5
//https://youtu.be/jFZvW79mOYE?si=z-DuU-jYUV-4Xzyd
// This is the video where i got the idea to use the CineMachine Tool

//2D Smooth Camera Follow in Unity Tutorial
//Muddy Wolf
// Accessed ; 20 March 2025
//Version 5
//https://youtu.be/8rnRvotQmdg?si=5PZBqpTSvMCcmcVe


//Idle, Run and Jump Animations - Platformer Unity 2D
//Game Code Library
//Accessed 27 April 2025
//Code Version 1
// https://youtu.be/Sg_w8hIbp4Y?si=tqGFvkcSpyc9L_No


//【【Unity3D像素游戏项目入门教程】20：——游戏中AudioSource音效的导入实现。-哔哩哔哩】 https://b23.tv/yLgx2SJ  <<//Movement sound

using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public int speed;
    public Rigidbody2D player;
    public AudioSource Walking;
    public Animator animator;
    public Camera cam;
    public float camAng =180;
    Vector2 mousePos;
    Vector2 movement;
    private float animMovement = 1f;
    private bool isColliding;
    private bool isDashing; //Plan to add dash next iteration
    public float dashDistance;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animMovement = movement.x + movement.y;
        animator.SetFloat("Speed",Mathf.Abs(animMovement)); 
      
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        player .MovePosition (player.position + movement*speed* Time.deltaTime);
        
        Vector2 lookDir = mousePos - player.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) *Mathf.Rad2Deg + camAng;

        player.rotation = angle;

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        bool isMoving = (Horizontal != 0f || Vertical != 0f);

        if (isMoving)
        {
            if (!Walking.isPlaying)
            {
                Walking.Play();

            }
        }
        else
        { 
            if (Walking.isPlaying) {   
                Walking.Stop(); }
        }
       
    }    
    void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        player.linearVelocity = Vector2.zero; 
    }

    
    void FixedUpdate()
    {
        if (isColliding)
        {
            if (movement.magnitude > 0.1f)
            {
                player.linearVelocity = movement.normalized * speed;
            }
            else
            {
                player.linearVelocity = Vector2.zero;
            }

        }
    }
   
    }
