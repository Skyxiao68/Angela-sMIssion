using System.Security.Cryptography;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int heal = 10;
    [Header("Healing Sound")]
    public AudioClip HealSound;
    [Range(0f, 1f)] public float volume = 0.7f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health amountHealed))
        {

            PlayHealSound();

            amountHealed.Heal(heal);

            Destroy(gameObject);

        }
    }

    void PlayHealSound()
    {
        if (HealSound != null)
        {
            // Play at pickup position with specified volume
            AudioSource.PlayClipAtPoint(HealSound, transform.position, volume);
        }
    }
}
 