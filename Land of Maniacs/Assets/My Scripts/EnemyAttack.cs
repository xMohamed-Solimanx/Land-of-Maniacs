using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent Nav;
    [SerializeField] Animator Anim;

    private NavMeshHit hit;

    private bool Blocked = false;
    private bool RunToPlayer = false;
    private float DistanceToPlayer;
    private bool IsChecking = true;
    private int FailedChecks = 0;

    [SerializeField] Transform Player;
    [SerializeField] GameObject Enemy;
    [SerializeField] float MaxRange = 35.0f;
    [SerializeField] int MaxChecks = 3;
    [SerializeField] float ChaseSpeed = 8.5f;
    [SerializeField] float WalkSpeed = 1.6f;
    [SerializeField] float AttackDistance = 2.3f;
    [SerializeField] float AttackRotateSpeed = 2.0f;
    [SerializeField] float CheckTime = 3.0f;










    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector3.Distance(Player.position, Enemy.transform.position);
        if (DistanceToPlayer < MaxRange)
        {
            if (IsChecking == true)
            {
                IsChecking = false;

                Blocked = NavMesh.Raycast(transform.position, Player.position, out hit, NavMesh.AllAreas);

                if (Blocked == false)
                {
                    Debug.Log("I can see the player");
                    RunToPlayer = true;
                }
                if (Blocked == true)
                {
                    Debug.Log("Where did the player go?!");
                    RunToPlayer = false;
                    Anim.SetInteger("State", 1);
                }

                StartCoroutine(TimedCheck());


            }
        }

        if (RunToPlayer)
        {
            Enemy.GetComponent<EnemyMove>().enabled = false;
            if (DistanceToPlayer > AttackDistance)
            {
                Nav.isStopped = false;
                Anim.SetInteger("State", 2);
                Nav.acceleration = 24;
                Nav.SetDestination(Player.position);
                Nav.speed = ChaseSpeed;
            }
            if (DistanceToPlayer < AttackDistance)
            {
                Nav.isStopped = true;
                Debug.Log("I am attacking");
               // Anim.SetInteger("State", 2);
                Nav.acceleration = 180;         //The higher the acceleration, the enemy won't slide when stopping'
            }
        }
        else if (RunToPlayer == false)
        {
            Nav.isStopped = true;
        }

    }

    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(CheckTime);
        IsChecking = true;
    }


}
