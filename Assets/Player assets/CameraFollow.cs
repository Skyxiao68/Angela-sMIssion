using UnityEngine;
using System.Collections;
public class CameraFollow : MonoBehaviour
{

    


















    private Vector3 offset;
    [SerializeField] private float damping;
    public Transform target;
    private Vector3 vel= Vector3.zero;


public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
                yield return null; 
        }
        transform.localPosition = originalPos;
    }




    void Update()
    {
        Vector3 targetPos = target.position + offset;
        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos,ref vel, damping);
    }
}
