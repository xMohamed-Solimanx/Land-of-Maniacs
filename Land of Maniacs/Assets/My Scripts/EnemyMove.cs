using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent Nav;
    private Transform TheTarget;
    private float DistanceToTarget;

    private int TargetNumber = 1;
    private bool HasStopped = false;



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

   // private bool CanPatrol = false; //used to delay the Update() untill the Coroutine (StartElements) is finished


    [SerializeField] float WaitTime = 2.0f;
   // [SerializeField] int MaxTargets;
    [SerializeField] float StopDistance = 2.0f;

    private bool forward = true;

    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        Nav.avoidancePriority = Random.Range(2, 65); // to avoid enemies pushing themselves and players
        TheTarget = Target1;

        //CanPatrol = true;
        // StartCoroutine(StartElements()); // Used to make sure that savescript is loaded first in the fpscontroller so then we can assign the targets to enemy move


    }

    // Update is called once per frame
    void Update()
    {
       // if (CanPatrol == true)
       // {
            DistanceToTarget = Vector3.Distance(TheTarget.position, transform.position);

            if (DistanceToTarget > StopDistance)
            {
                Nav.SetDestination(TheTarget.position);
                Nav.isStopped = false;
                Anim.SetInteger("State", 0);
            }

            if (DistanceToTarget < StopDistance && forward)
            {

                if (TargetNumber > 8)   //if going to first cube (target) then stop and change animation
                {
                    Nav.isStopped = true;
                    Anim.SetInteger("State", 1);
                    StartCoroutine(LookAround());
                }

                else
                {
                    TargetNumber++;
                    if (TargetNumber > 9)   //if arrived at first cube then switch direction
                    {

                        forward = false;
                        TargetNumber = 8;
                    }
                    SetTarget();
                }

            }
            else if (DistanceToTarget < StopDistance && !forward)
            {
                if (TargetNumber < 2)
                {
                    Nav.isStopped = true;
                    Anim.SetInteger("State", 1);
                    StartCoroutine(LookAround2());
                }
                else
                {
                    TargetNumber--;
                    if (TargetNumber < 1)
                    {
                        forward = true;
                        TargetNumber = 2;
                    }
                    SetTarget();
                }



            }
       // }
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
            TargetNumber++;
            if (TargetNumber > 9)
            {
                forward = false;
                TargetNumber = 8;
            }
            SetTarget();
            yield return new WaitForSeconds(WaitTime);
            HasStopped = false;
        }
    }

    IEnumerator LookAround2()
    {
        yield return new WaitForSeconds(WaitTime);
        if (HasStopped == false)
        {
            HasStopped = true;
            TargetNumber--;
            if (TargetNumber < 1)
            {
                forward = true;
                TargetNumber = 2;
            }
            SetTarget();
            yield return new WaitForSeconds(WaitTime);
            HasStopped = false;
        }
    }


   /* IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);


        Target1 = SaveScript.Target1;
        Target2 = SaveScript.Target2;
        Target3 = SaveScript.Target3;
        Target4 = SaveScript.Target4;
        Target5 = SaveScript.Target5;
        Target6 = SaveScript.Target6;
        Target7 = SaveScript.Target7;
        Target8 = SaveScript.Target8;
        Target9 = SaveScript.Target9;
        Target10 = SaveScript.Target10;
        TheTarget = Target1;
        Nav.avoidancePriority = Random.Range(2, 65); // to avoid enemies pushing themselves and players
        CanPatrol = true;
    }*/
}
