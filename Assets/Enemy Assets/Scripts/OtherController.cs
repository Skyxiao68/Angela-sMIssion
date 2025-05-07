using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    public enum State { Default, Idle, Patrol, Follow }
    public State currentState = State.Idle;
    public State defaultState;
    

    public Patrol patrol;
    public Follow follow;

    [Header("Raycast Settings")]
    [SerializeField] private float _detectionRange = 10f; // How far the enemy can "see"
    [SerializeField] private LayerMask _playerLayer;      // Layer the player is on
    [SerializeField] private float _raycastInterval = 0.2f; // How often to check (for performance)
    [SerializeField] private bool _debugRays = true;      // Visualize rays in Scene view

    private Transform _player;
    private float _nextRaycastTime;

    void Start()
    {
        defaultState = currentState;
        SwitchState(currentState);

        // Cache player reference
        _player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (_player == null)
            Debug.LogError("Player not found! Ensure it has the 'Player' tag.");
    }

    void Update()
    {
        // Only check at intervals (optimization)
        if (Time.time >= _nextRaycastTime)
        {
            CheckForPlayer();
            _nextRaycastTime = Time.time + _raycastInterval;
        }
    }

    private void CheckForPlayer()
    {
        if (_player == null) return;

        Vector2 directionToPlayer = (_player.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        // Only follow if player is in range
        if (distanceToPlayer <= _detectionRange)
        {
            // Raycast to check line of sight
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                directionToPlayer,
                _detectionRange,
                _playerLayer
            );

            // Debug visualization
            if (_debugRays)
                Debug.DrawRay(transform.position, directionToPlayer * _detectionRange, Color.red, _raycastInterval);

            // If ray hits the player, switch to Follow state
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                SwitchState(State.Follow);
            }
            else
            {
                // Player is out of sight but might still be in range
                SwitchState(State.Patrol);
            }
        }
        else
        {
            // Player is out of range entirely
            SwitchState(State.Patrol);
        }
    }

    public void SwitchState(State newState)
    {
        currentState = newState;
        if (patrol != null) patrol.enabled = (newState == State.Patrol);
        if (follow != null) follow.enabled = (newState == State.Follow);
    }
}
