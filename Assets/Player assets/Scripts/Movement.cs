using UnityEngine;
using System.Collections;
public class Movement : MonoBehaviour
{
    public int speed = 2;
    public Rigidbody2D player;

    public Animator animator;
    public Camera cam;
    public float camAng =180;
    Vector2 mousePos;
    Vector2 movement;
    private float animMovement = 1f;

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
    }

    
}
