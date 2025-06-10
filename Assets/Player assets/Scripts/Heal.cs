using UnityEngine;

public class Heal : MonoBehaviour
{
    public int heal = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health amountHealed)) 
        { 
        
         amountHealed.Heal (heal);
         Destroy(gameObject);
        
        }
    }
}
 