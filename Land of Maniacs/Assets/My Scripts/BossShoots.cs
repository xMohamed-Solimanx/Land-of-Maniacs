using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoots : MonoBehaviour
{
    [SerializeField] Animator Anim;
    [SerializeField] Transform ShootScript;
    private bool CanShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        ShootScript.GetComponent<SimpleShootBoss>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)     //If the player enters the boss shoot zone collider
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanShoot = true;                        //Shoot the player
            Anim.SetTrigger("AimShoot");
            StartCoroutine(ShootPlayer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanShoot = false;                          //Don't shoot
            StartCoroutine(ShootPlayer());
        }
    }







    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(1f);
        if (CanShoot == true)
        {
            ShootScript.GetComponent<SimpleShootBoss>().enabled = true;

        }
        if (CanShoot == false)
        {
            ShootScript.GetComponent<SimpleShootBoss>().enabled = false;

        }
    }





}
