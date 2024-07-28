using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum AIState
{
    IDLE, PATROL, CHASE, ATTACK
}

public class EnemyAI : MonoBehaviour
{
    [SerializeField] AudioSource chaseSound;
    [SerializeField] GameObject playerObject;
    [SerializeField] float playerDistance = 10f; 
    
    [SerializeField] float patrolRadius = 3f;
    [SerializeField] List<Transform> patrolPoints = new List<Transform>();

    int currentPatrolPoint = 0;
    AIState state;
    NavMeshAgent agent;

    [SerializeField] float idleDelay = 3f; 
    float idleTimer = 0f;

    [SerializeField] float attackRange = 2f; 
    [SerializeField] float attackCooldown = 1f; 
    float attackTimer = 0f;

    private Animator anim;
    void Start()
    {
        state = AIState.PATROL;
        agent = GetComponent<NavMeshAgent>();
        currentPatrolPoint = 0;
        anim = GetComponent<Animator>();
        UpdateAnimationState();
    }
    void ChangeState(AIState newState)
    {
        Debug.Log($"Changing state from {state} to {newState}");
        state = newState;
        idleTimer = 0f;
        attackTimer = 0f;
        UpdateAnimationState();
    }

    void CheckForPlayer()
    {
        if (DistanceCheck(transform.position, playerObject.transform.position, playerDistance))
        {
            ChangeState(AIState.CHASE);
        }
        else if (state == AIState.CHASE)
        {
           
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleDelay)
            {
                ChangeState(AIState.IDLE);
            }
        }
        else if (state == AIState.IDLE)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleDelay)
            {
                ChangeState(AIState.PATROL);
            }
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
            case AIState.ATTACK:
                Attack();
                break;
        }
    }

    void Patrol()
    {
        if (patrolPoints.Count == 0)
            return;

        if ((transform.position - patrolPoints[currentPatrolPoint].position).magnitude < patrolRadius)
        {
            currentPatrolPoint = GetNextPatrolPoint();
        }
        else
        {
            SetDestination(patrolPoints[currentPatrolPoint]);
        }
    }

    int GetNextPatrolPoint()
    {

        return (currentPatrolPoint + 1) % patrolPoints.Count;
    }

    void Chase()
    {
        if (DistanceCheck(transform.position, playerObject.transform.position, attackRange))
        {
            ChangeState(AIState.ATTACK);
        }
        else if (DistanceCheck(transform.position, playerObject.transform.position, playerDistance))
        {

            SetDestination(playerObject.transform.position);
        }
        else
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleDelay)
            {
                ChangeState(AIState.IDLE);
            }
        }
        FacePlayer();
    }

    void Attack()
    {
        if (DistanceCheck(transform.position, playerObject.transform.position, attackRange))
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown)
            {
                
                attackTimer = 0f;
            }
        }
        else
        {
            ChangeState(AIState.CHASE);
        }
        FacePlayer();
    }

    void Idle()
    {
       
        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDelay)
        {
            
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

    private void UpdateAnimationState()
    {
       
        anim.SetBool("isIdling", state == AIState.IDLE);
        anim.SetBool("isWalking", state == AIState.PATROL);
        anim.SetBool("isRunning", state == AIState.CHASE);
        anim.SetBool("isAttacking", state == AIState.ATTACK);
    }

    private void FacePlayer()
    {
        Vector3 directionToPlayer = playerObject.transform.position - this.transform.position;
        directionToPlayer.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }
}