using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFMS : MonoBehaviour
{
    public float speed;
    public GameObject player;

    public bool isRight = false;
    public bool CanMove = true;
    public float attackDistance = 0.5f;
    public float patrolRange = 5f;
    public Transform leftPatrolPoint;
    public Transform rightPatrolPoint;

    private Vector3 initialScale;
    private Enemy enemy;
    private Vector3 targetPosition;

    private enum State
    {
        Patrolling,
        Chasing,
        Attacking
    }

    private State currentState;

    void Start()
    {
        initialScale = transform.localScale;
        enemy = GetComponent<Enemy>();
        currentState = State.Patrolling;
        SetNextPatrolPosition();
    }

    void Update()
    {
        if (CanMove)
        {
            switch (currentState)
            {
                case State.Patrolling:
                    Patrol();
                    break;
                case State.Chasing:
                    ChasePlayer();
                    break;
                case State.Attacking:
                    // Handle attacking logic in the Enemy script
                    break;
            }
        }
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNextPatrolPosition();
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.transform.position) <= patrolRange)
        {
            currentState = State.Chasing;
        }
    }

    private void SetNextPatrolPosition()
    {
        targetPosition = (Random.Range(0f, 1f) > 0.5f) ? leftPatrolPoint.position : rightPatrolPoint.position;
        FlipSprite(targetPosition == rightPatrolPoint.position);
    }

    private void ChasePlayer()
    {
        Vector3 heading = player.transform.position - transform.position;

        if (heading.x < 0)
        {
            FlipSprite(false);
        }
        else
        {
            FlipSprite(true);
        }

        if (Vector2.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            currentState = State.Attacking;
            CanMove = false;
            enemy.Attack();
        }
        else if (Vector2.Distance(transform.position, player.transform.position) > patrolRange)
        {
            currentState = State.Patrolling;
            SetNextPatrolPosition();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void FlipSprite(bool facingRight)
    {
        transform.localScale = new Vector3(facingRight ? initialScale.x : -initialScale.x, initialScale.y, initialScale.z);
    }

    public void OnAttackComplete()
    {
        CanMove = true;
        currentState = State.Chasing;
    }

    public void ResumeAfterDamage()
    {
        CanMove = true;
        if (Vector3.Distance(transform.position, player.transform.position) <= patrolRange)
        {
            currentState = State.Chasing;
        }
        else
        {
            currentState = State.Patrolling;
        }
    }
}
