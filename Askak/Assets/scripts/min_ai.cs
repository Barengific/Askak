using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class min_ai : MonoBehaviour { 
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGrounded, whatIsPlayer;
    
    //patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSigntRange, PlayerInAttackRange;

    private void Awake()    {
        player = GameObject.Find("Cube").transform;
        //player = 
        agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        playerInSigntRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSigntRange && !PlayerInAttackRange) Patrol();
        if (playerInSigntRange && !PlayerInAttackRange) Chase();
        if (playerInSigntRange && PlayerInAttackRange) Attack();
    }

    public void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distWalk = transform.position - walkPoint;

        //walkpoint rearch
        if (distWalk.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGrounded))
            walkPointSet = true;
    }
    public void Chase()
    {
        agent.SetDestination(player.position);

    }
    public void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

    }

    private void ResetAttack(){
        alreadyAttacked = false;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


  
}
