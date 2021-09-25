using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{

    [SerializeField] int WeaponDamage = 1;
    [SerializeField] Animator HurtAnim;
    [SerializeField] AudioSource MyPlayer;

    private bool HitActive = false;

    [SerializeField] GameObject FPSArms; //used to decrease player stamina when hit by enemies


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (HitActive == false) //to deliver 1 hit damage and not multiple damage per attack
            {
                HitActive = true;
                SaveScript.PlayerHealth -= WeaponDamage;
                SaveScript.HealthChanged = true;
                Debug.Log("Hit the player");
                HurtAnim.SetTrigger("Hurt");
                MyPlayer.Play();
                FPSArms.GetComponent<PlayerAttacks>().AttackStamina -= 0.2f;
                ResetHit();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (HitActive == true) //to deliver 1 hit damage and not multiple damage per attack
            {
                HitActive = false;
            }
        }
    }


    IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(1f);
        if(HitActive == true)
        {
            HitActive = false;
        }
    }




}
