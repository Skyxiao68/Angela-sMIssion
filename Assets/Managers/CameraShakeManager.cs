//CAMERA SHAKE in Unity
//Brackeys
//Accessed 26 April 2025
//Version 2
//https://youtu.be/9A9yj8KnM8c?si=l04Ec1sOjvcc9A4J



using Unity.Cinemachine;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{
   public static CameraShakeManager instance;

    [SerializeField] private float globalShakeForce = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CameraShake (CinemachineImpulseSource source)
    {
        source.GenerateImpulseWithForce(globalShakeForce);
    }
}
 