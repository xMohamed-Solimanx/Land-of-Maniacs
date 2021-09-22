﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUIScript : MonoBehaviour
{
    [SerializeField] Text BulletAmt;
    // Start is called before the first frame update
    void Start()
    {
        BulletAmt.text = SaveScript.Bullets + "";
    }

    // Update is called once per frame
    void Update()
    {
        BulletAmt.text = SaveScript.Bullets + "";

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (SaveScript.Bullets > 0)
                {
                    SaveScript.Bullets -= 1;
                   // BulletAmt.text = SaveScript.Bullets + "";

                }
            }
        }
    }
}
