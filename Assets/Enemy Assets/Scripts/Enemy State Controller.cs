using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    public enum State { Default ,Idle ,Patrol,Follow}
    public State currentState = State.Idle;
    public State defaultState;

    public Patrol patrol;
    public Follow follow;
    void Start()
    {
        defaultState = currentState;
        SwitchState (currentState);
    }

    public void SwitchState(State newState)
    {
        currentState= newState;
        if (patrol != null) patrol.enabled = (newState == State.Patrol);
        if (follow != null) follow.enabled = ( newState == State.Follow );
    }

   
   
}
