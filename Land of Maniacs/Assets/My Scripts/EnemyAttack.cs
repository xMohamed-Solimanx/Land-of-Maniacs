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

    [SerializeField] GameObject ChaseMusic;



    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponentInParent<NavMeshAgent>();
        ChaseMusic.gameObject.SetActive(false);
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

                if (Blocked == false) // can see the player
                {
                    Debug.Log("I can see the player");
                    RunToPlayer = true;
                    FailedChecks = 0;
                }
                if (Blocked == true) // can't see the player
                {
                    Debug.Log("Where did the player go?!");
                    RunToPlayer = false;
                    Anim.SetInteger("State", 1);
                    FailedChecks++;
                }

                StartCoroutine(TimedCheck());


            }
        }

        if (RunToPlayer)
        {
            Enemy.GetComponent<EnemyMove>().enabled = false;
            ChaseMusic.gameObject.SetActive(true);
            if (DistanceToPlayer > AttackDistance)
            {
                Nav.isStopped = false;          //start moving
                Anim.SetInteger("State", 2);
                Nav.acceleration = 24;
                Nav.SetDestination(Player.position);
                Nav.speed = ChaseSpeed;
            }
            if (DistanceToPlayer < AttackDistance - 0.5f)
            {
                Nav.isStopped = true;           //stop moving
                Debug.Log("I am attacking");
                Anim.SetInteger("State", 3);
                Nav.acceleration = 180;         //The higher the acceleration, the enemy won't slide when stopping'

                Vector3 Pos = (Player.position - Enemy.transform.position).normalized;  //handling enemy rotation when attacking the player to make him face the player
                Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, PosRotation, Time.deltaTime * AttackRotateSpeed);
            }
        }
        else if (RunToPlayer == false)
        {
            Nav.isStopped = true;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RunToPlayer = true;
        }
    }

    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(CheckTime);
        IsChecking = true;

        if (FailedChecks > MaxChecks)
        {
            Enemy.GetComponent<EnemyMove>().enabled = true;
            Nav.isStopped = false;
            Nav.speed = WalkSpeed;
            FailedChecks = 0;
            ChaseMusic.gameObject.SetActive(false);
        }
    }


}
