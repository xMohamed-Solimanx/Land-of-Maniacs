﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent Nav;
    private Transform TheTarget;
    private float DistanceToTarget;
    private int TargetNumber = 1;


    [SerializeField] Transform Target1;
    [SerializeField] Transform Target2;
    [SerializeField] float StopDistance = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
        TheTarget = Target1;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTarget = Vector3.Distance(TheTarget.position, transform.position);

        if(DistanceToTarget > StopDistance)
        {
            Nav.SetDestination(TheTarget.position);
        }

        if (DistanceToTarget < StopDistance)
        {
            TargetNumber++;
            if (TargetNumber > 2)
            {
                TargetNumber = 1;
            }
            SetTarget();
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
    }

}
