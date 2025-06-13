using NavMeshPlus.Components;
using Unity.Cinemachine;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [Header("Effects")]
    public ParticleSystem destructionParticles; 
   
    public CinemachineImpulseSource destruction;
  

    private void Start()
    {
        destruction = GetComponent<CinemachineImpulseSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {

            CameraShakeManager.instance.CameraShake(destruction);

            if (destructionParticles != null)
            {
                Instantiate(destructionParticles, transform.position, Quaternion.identity);
            }

           
          

          
            Destroy(gameObject);
        }
    }
}