using UnityEngine;
using System.Collections;

public class FogOfWarPlayer : MonoBehaviour
{
    public Transform player;
    
    void Update()
    {
        transform.position = player.position;
        transform.rotation = player.rotation;
    }
}
