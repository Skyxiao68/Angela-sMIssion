using UnityEngine;
using System.Collections;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
public class Movement : MonoBehaviour
{
    public int speed = 2;
    public Rigidbody2D player;

    public AudioSource Walking;
    public Animator animator;
    public Camera cam;
    public float camAng =180;
    Vector2 mousePos;
    Vector2 movement;
    private float animMovement = 1f;
    private bool isColliding;
    private bool isDashing;
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
