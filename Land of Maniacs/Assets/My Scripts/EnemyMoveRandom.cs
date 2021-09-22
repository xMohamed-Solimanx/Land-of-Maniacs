using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveRandom : MonoBehaviour
{
    private NavMeshAgent Nav;
    private Transform TheTarget;
    private float DistanceToTarget;

    private int TargetNumber = 1;
    private bool HasStopped = false;
    private bool Randomizer = true;
    private int NextTargetNumber;



    private Animator Anim;

    [SerializeField] Transform Target1;
    [SerializeField] Transform Target2;
    [SerializeField] Transform Target3;
    [SerializeField] Transform Target4;
    [SerializeField] Transform Target5;
    [SerializeField] Transform Target6;
    [SerializeField] Transform Target7;
    [SerializeField] Transform Target8;
    [SerializeField] Transform Target9;

    [SerializeField] float WaitTime = 2.0f;
    [SerializeField] int MaxTargets;
    [SerializeField] float StopDistance = 2.0f;

    private bool forward = true;

    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
        TheTarget = Target1;
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTarget = Vector3.Distance(TheTarget.position, transform.position);

        if(DistanceToTarget > StopDistance)
        {
            Nav.SetDestination(TheTarget.position);
            Nav.isStopped = false;
            Anim.SetInteger("State", 0);
            NextTargetNumber = TargetNumber;
            Nav.speed = 1.6f;
        }

        if (DistanceToTarget < StopDistance)
        {

            Nav.isStopped = true;
            Anim.SetInteger("State", 1);
            StartCoroutine(LookAround());

        }
        
    }

    void SetTarget()
    {
        if (TargetNumber == 1)
        {
            TheTarget = Target1;
        }

        if (TargetNumber == 2)
        {
            TheTarget = Target2;
        }
        if (TargetNumber == 3)
        {
            TheTarget = Target3;
        }
        if (TargetNumber == 4)
        {
            TheTarget = Target4;
        }
        if (TargetNumber == 5)
        {
            TheTarget = Target5;
        }
        if (TargetNumber == 6)
        {
            TheTarget = Target6;
        }
        if (TargetNumber == 7)
        {
            TheTarget = Target7;
        }
        if (TargetNumber == 8)
        {
            TheTarget = Target8;
        }
        if (TargetNumber == 9)
        {
            TheTarget = Target9;
        }
    }
    

    IEnumerator LookAround()
    {
        yield return new WaitForSeconds(WaitTime);

        if (HasStopped == false)
        {
            HasStopped = true;
            if (Randomizer == true)
            {
                Randomizer = false;
                TargetNumber = Random.Range(1, MaxTargets);


                if (TargetNumber == NextTargetNumber)  // if next target is the same target the enemy is standing at right now
                {
                    TargetNumber++;

                    if (TargetNumber >= MaxTargets) // to avoid going to a target that doesn't exist
                    {
                        TargetNumber = 1;
                    }
                }
            }
            SetTarget();
            yield return new WaitForSeconds(WaitTime);
            HasStopped = false;
            Randomizer = true;
        }
    }
}
