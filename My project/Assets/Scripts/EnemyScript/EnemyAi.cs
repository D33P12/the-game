using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum AIState
{
    IDLE, PATROL, CHASE
}

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    AudioSource chaseSound;

    [SerializeField]
    GameObject playerObject;
   

    [SerializeField]
    float playerDistance = 10f;
    float destinationDistance = 2f;
    Vector3 chasePosition;

   
    [SerializeField]
    List<Transform> patrolPoints = new List<Transform>();

    [SerializeField]
    float patrolRadius = 3f;

    int currentPatrolPoint = 0;
   

    AIState state;
    NavMeshAgent agent;
    [SerializeField]
    float idleDelay = 3f;
    float idleTimer = 0f;
    void Start()
    {
        state = AIState.PATROL;
        agent = GetComponent<NavMeshAgent>();
        currentPatrolPoint = 0;

    }
    void ChangeState(AIState newState)
    {
        switch (newState)
        {
            case AIState.IDLE:

                break;
            case AIState.PATROL:

                break;
            case AIState.CHASE:

                break;

        }
        state = newState;
        idleTimer = 0f;
    }
    void CheckForPlayer()
    {
        if (DistanceCheck(transform.position, playerObject.transform.position, playerDistance))
        {
            ChangeState(AIState.CHASE);
        }
    }
    bool DistanceCheck(Vector3 position1, Vector3 position2, float distance)
    {
        return (position1 - position2).magnitude < distance;
    }
    void Update()
    {
        CheckForPlayer();
        switch (state)
        {
            case AIState.IDLE:
                Idle();
                break;
            case AIState.PATROL:
                Patrol();
                break;
            case AIState.CHASE:
                Chase();
                break;

        }
    }

    void Patrol()
    {
        if ((transform.position - patrolPoints[currentPatrolPoint].position).magnitude < patrolRadius)
        {
            currentPatrolPoint = GetNextPatrolPoint();
        }
        SetDestination(patrolPoints[currentPatrolPoint]);
    }

    int GetNextPatrolPoint()
    {
        if (patrolPoints.Count == 0)
            return -1;
        else
            return (currentPatrolPoint + 1) % patrolPoints.Count;
    }

    void Chase()
    {
        if (DistanceCheck(transform.position, playerObject.transform.position, playerDistance))
        {
            SetDestination(playerObject.transform.position);
            chasePosition = playerObject.transform.position;


        }
        else if (DistanceCheck(transform.position, chasePosition, destinationDistance))
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleDelay)
            {
                ChangeState(AIState.PATROL);
            }
        }

    }

    void Idle() // it is paused for few seconds going back to chase or patrol
    {
        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDelay)
        {

            transform.rotation = Quaternion.identity;
            ChangeState(AIState.PATROL);

        }

    }

    void SetDestination(Transform destinationTransform)
    {
        agent.SetDestination(destinationTransform.position);
    }
    void SetDestination(Vector3 position)
    {
        agent.SetDestination(position);
    }
}
