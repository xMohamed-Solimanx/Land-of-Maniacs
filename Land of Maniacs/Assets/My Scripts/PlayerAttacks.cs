using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private Animator Anim;
    [SerializeField] GameObject Crosshair;
    [SerializeField] GameObject Pointer;

    private AudioSource MyPlayer;
    [SerializeField] AudioClip GunShotSound;
    [SerializeField] AudioClip EmptyGunSound;
    [SerializeField] AudioClip CrossbowAim;
    [SerializeField] AudioClip CrossbowFire;




    public float AttackStamina; //To get the current (realtime) attack stamina amount
    [SerializeField] float MaxAttackStamina = 10;
    [SerializeField] float AttackDrain = 2;
    [SerializeField] float AttackRefill = 1;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        AttackStamina = MaxAttackStamina;
        Crosshair.gameObject.SetActive(false);
        Pointer.gameObject.SetActive(true);
        MyPlayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Attack Stamina" + AttackStamina);
        if (AttackStamina < MaxAttackStamina)
        {
            AttackStamina += AttackRefill * Time.deltaTime;
        }
        if(AttackStamina <= 0.1)
        {
            AttackStamina = 0.1f;
        }
        if (AttackStamina > 3.0)
        {
            if (SaveScript.HaveKnife == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Anim.SetTrigger("KnifeLMB");
                    AttackStamina -= AttackDrain;
                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Anim.SetTrigger("KnifeRMB");
                    AttackStamina -= AttackDrain;

                }
            }

            if (SaveScript.HaveBat == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Anim.SetTrigger("BatLMB");
                    AttackStamina -= AttackDrain;

                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Anim.SetTrigger("BatRMB");
                    AttackStamina -= AttackDrain;

                }
            }

            if (SaveScript.HaveAxe == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Anim.SetTrigger("AxeLMB");
                    AttackStamina -= AttackDrain;

                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Anim.SetTrigger("AxeRMB");
                    AttackStamina -= AttackDrain;

                }
            }

            if (SaveScript.HaveGun == true)
            {
                
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    Anim.SetBool("AimGun", true);
                    Crosshair.gameObject.SetActive(true);
                    Pointer.gameObject.SetActive(false);

                    if (SaveScript.Bullets > 0)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0)) //left mouse button
                        {
                            MyPlayer.clip = GunShotSound;
                           // MyPlayer.Play();
                        }
                    }
                    if (SaveScript.Bullets <= 0)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0)) //left mouse button
                        {
                            MyPlayer.clip = EmptyGunSound;
                            MyPlayer.Play();
                        }
                    }



                }
                if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    Crosshair.gameObject.SetActive(false);
                    Pointer.gameObject.SetActive(true);
                    Anim.SetBool("AimGun", false);

                }
                /*if (Input.GetKeyDown(KeyCode.Mouse0)) //left mouse button
                {
                    MyPlayer.clip = GunShotSound;
                    MyPlayer.Play();
                }*/

            }
            if (SaveScript.HaveCrossbow == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    MyPlayer.clip = CrossbowAim;
                    MyPlayer.Play();
                }
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    Anim.SetBool("AimCrossbow", true);
                    Crosshair.gameObject.SetActive(true);
                    Pointer.gameObject.SetActive(false);

                    if (SaveScript.Arrows > 0)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0)) //left mouse button
                        {
                            MyPlayer.clip = CrossbowFire;
                            MyPlayer.Play();
                        }
                    }
                    if (SaveScript.Arrows <= 0)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0)) //left mouse button
                        {
                            MyPlayer.clip = EmptyGunSound;
                            MyPlayer.Play();
                        }
                    }



                }
                if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    Crosshair.gameObject.SetActive(false);
                    Pointer.gameObject.SetActive(true);
                    Anim.SetBool("AimCrossbow", false);

                }








                /*if (Input.GetKeyDown(KeyCode.Mouse0)) //left mouse button
                {
                    MyPlayer.clip = GunShotSound;
                    MyPlayer.Play();
                }*/

            }
        }
        
    }
}
