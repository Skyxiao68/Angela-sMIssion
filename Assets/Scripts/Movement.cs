using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 2;
    
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(moveX, moveY)* speed * Time.deltaTime;  
        transform.Translate (move);
    }
}
