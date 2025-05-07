using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] int speed = 1;
    public Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
