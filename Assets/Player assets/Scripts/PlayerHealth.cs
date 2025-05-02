using UnityEngine;
using TMPro;
public class Health : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth = 0;
    public TextMeshProUGUI hpDisplay;
    public int amountHealed = 20;

   
    void Start()
    {
        currentHealth = maxHealth;
        hpDisplay.text = maxHealth.ToString();
    }

   
    public void RecieveDamage (int damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth<= 0)
        {
            Die();
        }
        hpDisplay.text = currentHealth.ToString();
    }
    void Die()
    {

        //do an animation set a timer and then do the gameover 
       // gameOver.SetActive(true);
        Time.timeScale = 0;

        
    }
    public void Heal (int amountHealed)
    {
        currentHealth += amountHealed;
    }
}
