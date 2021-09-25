﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsPickup : MonoBehaviour
{
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject Bat;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject Gun;
    [SerializeField] GameObject Crossbow;
    [SerializeField] GameObject CabinKey;
    [SerializeField] GameObject HouseKey;
    [SerializeField] GameObject RoomKey;
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] GameObject Enemy4;
    [SerializeField] GameObject Enemy5;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(1);

        if(SaveScript.Knife == true)
        {
            Destroy(Knife.gameObject);
        }
        if (SaveScript.Axe == true)
        {
            Destroy(Axe.gameObject);
        }
        if (SaveScript.BaseballBat == true)
        {
            Destroy(Bat.gameObject);
        }
        if (SaveScript.Crossbow == true)
        {
            Destroy(Crossbow.gameObject);
        }
        if (SaveScript.Handgun == true)
        {
            Destroy(Gun.gameObject);
        }
        if (SaveScript.CabinKey == true)
        {
            Destroy(CabinKey.gameObject);
        }
        if (SaveScript.HouseKey == true)
        {
            Destroy(HouseKey.gameObject);
        }
        if (SaveScript.RoomKey == true)
        {
            Destroy(RoomKey.gameObject);
        }

        if(SaveScript.Enemy1 == 0)
        {
            Destroy(Enemy1.gameObject);
        }
        if (SaveScript.Enemy2 == 0)
        {
            Destroy(Enemy2.gameObject);
        }
        if (SaveScript.Enemy3 == 0)
        {
            Destroy(Enemy3.gameObject);
        }
        if (SaveScript.Enemy4 == 0)
        {
            Destroy(Enemy4.gameObject);
        }
        if (SaveScript.Enemy5 == 0)
        {
            Destroy(Enemy5.gameObject);
        }

    }
}
