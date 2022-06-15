using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;

    public GameObject playerRef;
    public Transform player;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    // States
    public bool playerInSightRange, playerInAttackRange;
    [SerializeField] public float radiusView;
    [SerializeField] public float radiusAttack;
    [Range(0, 360)]
    [SerializeField] public float angle;

    // Chase
    [SerializeField] public float MaxDist;
    [SerializeField] public float MinDist;

    // Attacking
    bool alreadyAttacked;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        if (playerRef == null)
            Debug.Log("no player");
        StartCoroutine(FOVRoutine());
        StartCoroutine(FOARoutine());
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInAttackRange = Physics.CheckSphere(transform.position, radiusAttack, targetMask);

        if (!playerInSightRange && !playerInAttackRange)
        {
            //Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            Chase();
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
    }

    /*
    private void Patroling()
    {
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, obstructionMask))
            walkPointSet = true;
    }
    */
    private void Chase()
    {
        transform.LookAt(playerRef.transform);

        if (Vector3.Distance(transform.position, playerRef.transform.position) >= MinDist)
        {
            transform.position += transform.forward * enemyStats.EnemySpeed * Time.deltaTime;
        }
    }

    private void AttackPlayer()
    {
        // Make sure the enemy doesn't move
        transform.position = transform.position;
        // Look at the player
        transform.LookAt(playerRef.transform);

        if (!alreadyAttacked)
        {
            /// Attack code here
            ///
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), enemyStats.TimeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        enemyStats.Hp -= damage;

        if (enemyStats.Hp <= 0)
            Invoke(nameof(DestroyEnemy), .5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private IEnumerator FOARoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfAttackCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radiusView, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    playerInSightRange = true;
                else
                    playerInSightRange = false;
            }
            else
                playerInSightRange = false;
        }
        else if (playerInSightRange)
            playerInSightRange = false;
    }

    private void FieldOfAttackCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radiusAttack, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    playerInAttackRange = true;
                else
                    playerInAttackRange = false;
            }
            else
                playerInAttackRange = false;
        }
        else if (playerInAttackRange)
            playerInAttackRange = false;
    }
}
