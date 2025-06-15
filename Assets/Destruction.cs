using NavMeshPlus.Components;
using Unity.Cinemachine;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [Header("Effects")]
    public ParticleSystem destructionParticles;
    public CinemachineImpulseSource destruction;

    [Header("Sound")]
    public AudioClip destructionSound;
    [Range(0f, 1f)] public float volume = 0.8f;
    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {

            PlayDestructionSound();


            if (destruction != null)
            {
                CameraShakeManager.instance.CameraShake(destruction);
            }


            if (destructionParticles != null)
            {
                Instantiate(destructionParticles, transform.position, Quaternion.identity);
            }


            Destroy(gameObject);
        }
    }

    void PlayDestructionSound()
    {
        if (destructionSound != null)
        {

            GameObject tempGO = new GameObject("TempAudio");
            tempGO.transform.position = transform.position;
            AudioSource audioSource = tempGO.AddComponent<AudioSource>();


            audioSource.clip = destructionSound;
            audioSource.volume = volume;
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.Play();


            Destroy(tempGO, destructionSound.length);
        }
    }
}