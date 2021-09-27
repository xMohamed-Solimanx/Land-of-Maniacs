using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script is attached to the spawn cube near the boss, so that he is only activated once you approach the room


public class BossActivate : MonoBehaviour
{
   // [SerializeField] GameObject EnemyDetectionZone;
   // [SerializeField] GameObject ShootZone;
    [SerializeField] GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        //EnemyDetectionZone.gameObject.SetActive(false);
       // ShootZone.gameObject.SetActive(false);
        Boss.gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // EnemyDetectionZone.gameObject.SetActive(true);
          //  ShootZone.gameObject.SetActive(true);
            Boss.gameObject.SetActive(true);
        }
    }
}
