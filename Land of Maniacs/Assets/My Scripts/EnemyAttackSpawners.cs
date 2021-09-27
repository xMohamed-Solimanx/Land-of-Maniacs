using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackSpawners : MonoBehaviour
{
    private NavMeshAgent Nav;
    [SerializeField] Animator Anim;

    private NavMeshHit hit;

    private bool Blocked = false;
    public  bool RunToPlayer = false;
    private float DistanceToPlayer;
    private bool IsChecking = true;
    private int FailedChecks = 0;

    [SerializeField] Transform Player;
    [SerializeField] GameObject Enemy;
    [SerializeField] float MaxRange = 35.0f;
    [SerializeField] int MaxChecks = 3;
    [SerializeField] float ChaseSpeed = 8.5f;
    [SerializeField] float WalkSpeed = 1.6f;
    [SerializeField] float AttackDistance = 3f;
    [SerializeField] float AttackRotateSpeed = 2.0f;
    [SerializeField] float CheckTime = 3.0f;

    [SerializeField] GameObject ChaseMusic;
    [SerializeField] GameObject HurtUI;

    [SerializeField] GameObject EnemyDamageZone; // to access HasDied bool to be able to turn off chase music after enemy death

        // To know what weapon the enemy is holding to trigger the right attack animation //
    [SerializeField] bool IHaveKnife;
    [SerializeField] bool IHaveBat;
    [SerializeField] bool IHaveAxe;

    private bool CanRun = false; //used to delay the Update() untill the Coroutine (StartElements) is finished


    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponentInParent<NavMeshAgent>();
        StartCoroutine(StartElements()); // Used to make sure that savescript is loaded first in the fpscontroller so then we can assign the targets to enemy move

        //StartCoroutine(StartWalking());
        

        

    }

    // Update is called once per frame
    void Update()
    {
        if (CanRun == true)
        {


            if (EnemyDamageZone.GetComponent<EnemyDamage>().HasDied == true) // if enemy is dead, turn off chase music
            {
                ChaseMusic.gameObject.SetActive(false);
            }
            DistanceToPlayer = Vector3.Distance(Player.position, Enemy.transform.position);
            if (DistanceToPlayer < MaxRange)
            {
                if (IsChecking == true)
                {
                    IsChecking = false;

                    Blocked = NavMesh.Raycast(transform.position, Player.position, out hit, NavMesh.AllAreas);

                    if (Blocked == false) // can see the player
                    {
                        // Debug.Log("I can see the player");
                        RunToPlayer = true;
                        FailedChecks = 0;
                    }
                    if (Blocked == true) // can't see the player
                    {
                        //Debug.Log("Where did the player go?!");
                        RunToPlayer = false;
                        Anim.SetInteger("State", 1);
                        FailedChecks++;
                    }

                    StartCoroutine(TimedCheck());


                }
            }

            if (RunToPlayer)
            {
                Enemy.GetComponent<EnemyMoveRandom>().enabled = false;
                if (EnemyDamageZone.GetComponent<EnemyDamage>().HasDied == false) // if false, play the chase music
                {
                    ChaseMusic.gameObject.SetActive(true);
                }

                if (DistanceToPlayer > AttackDistance)
                {
                    Nav.isStopped = false;          //start moving
                    Anim.SetInteger("State", 2);
                    Nav.acceleration = 24;
                    Nav.SetDestination(Player.position);
                    Nav.speed = ChaseSpeed;
                    HurtUI.gameObject.SetActive(false);

                }
                if (DistanceToPlayer < AttackDistance - 0.5f)
                {
                    Nav.isStopped = true;           //stop moving
                   // Debug.Log("I am attacking");
                    if (IHaveAxe == true)
                    {
                        Anim.SetInteger("State", 3);
                    }
                    if (IHaveBat == true)
                    {
                        Anim.SetInteger("State", 4);
                    }
                    if (IHaveKnife == true)
                    {
                        Anim.SetInteger("State", 5);
                    }
                    Nav.acceleration = 180;         //The higher the acceleration, the enemy won't slide when stopping'
                    HurtUI.gameObject.SetActive(true);

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

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RunToPlayer = true;
        }

        if (other.gameObject.CompareTag("PlayerKnife"))
        {
            Anim.SetTrigger("SmallReact");
        }

        if (other.gameObject.CompareTag("PlayerAxe"))
        {
            Anim.SetTrigger("BigReact");
        }

        if (other.gameObject.CompareTag("PlayerBat"))
        {
            Anim.SetTrigger("SmallReact");
        }
        if (other.gameObject.CompareTag("PlayerCrossbow"))
        {
            Anim.SetTrigger("BigReact");
            RunToPlayer = true;
        }
    }

    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(CheckTime);
        IsChecking = true;

        if (FailedChecks > MaxChecks)
        {
            Enemy.GetComponent<EnemyMoveRandom>().enabled = true;
            Nav.isStopped = false;
            Nav.speed = WalkSpeed;
            FailedChecks = 0;
            ChaseMusic.gameObject.SetActive(false);
        }
    }



    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);

        Player = SaveScript.PlayerChar;
        ChaseMusic = SaveScript.Chase;  // to auto fill this data once enemy is spawned
        HurtUI = SaveScript.HurtScreen;
        ChaseMusic.gameObject.SetActive(false);
        CanRun = true;
        CheckTime = Random.Range(3, 6);
        Anim.SetInteger("State", 1);


    }

   /* IEnumerator StartWalking()
    {
        yield return new WaitForSeconds(1f);
        RunToPlayer = true;
        yield return new WaitForSeconds(0.01f);
        RunToPlayer = false;
        ChaseMusic.gameObject.SetActive(false);
        Nav.speed = WalkSpeed;
    }*/


}
