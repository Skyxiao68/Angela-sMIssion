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
    }
    public void SwitchState(State newState)
    {
        currentState = newState;

        patrol.enabled = newState == State.Patrol;
        follow.enabled = newState == State.Follow;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SwitchState(State.Follow);
        patrol.enabled = false;
        follow.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SwitchState(State.Patrol);
        patrol.enabled = true;
        follow.enabled = false;
    }
}
