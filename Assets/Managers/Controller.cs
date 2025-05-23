using UnityEngine;

public class Controller : MonoBehaviour
{
    public enum State { Default, Idle, Patrol, Follow }
    public State currentState = State.Patrol;
    private State defaultState;

    public Patrol patrol;
    public Follow follow;


    void Start()
    {
        defaultState = currentState;
        SwitchState(currentState);
        patrol.enabled = true;
        follow.enabled = false;
    }
    public void SwitchState(State newState)
    {

        patrol.enabled = false;
        follow.enabled = false;
        currentState = newState;

        switch (newState)
        {
            case State.Patrol:
                patrol.enabled = true;
                break;

            case State.Follow:
                follow.enabled = true;
                break;  
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SwitchState(State.Follow);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player"))
            SwitchState(State.Patrol);
       
    }

}
