using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private float damping;
    public Transform target;
    private Vector3 vel= Vector3.zero;

    void Update()
    {
        Vector3 targetPos = target.position + offset;
        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos,ref vel, damping);
    }
}
