using UnityEngine;
using System.Collections;
public class Movement : MonoBehaviour
{
    public int speed = 2;
    public Rigidbody2D player;

    public Camera cam;
    public float camAng =180;
    Vector2 mousePos;
    Vector2 movement; 
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       
        //instantiate animations for walking 

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        player .MovePosition (player.position + movement*speed* Time.deltaTime);
        Vector2 lookDir = mousePos - player.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) *Mathf.Rad2Deg + camAng;

        player.rotation = angle;
    }

    
}
