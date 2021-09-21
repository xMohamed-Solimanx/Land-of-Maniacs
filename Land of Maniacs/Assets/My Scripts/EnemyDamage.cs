using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int EnemyHealth = 100;
    private AudioSource MyPlayer;
    [SerializeField] AudioSource StabPlayer;
    private Animator Anim;

    [SerializeField] GameObject EnemyObject; //To destroy the enemy object after death

    public bool HasDied = false; //used in Update() so that the death animation doesn't loop
    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = GetComponent<AudioSource>();
        Anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyHealth <= 0)
        {
            if(HasDied == false)
            {
                Anim.SetTrigger("Death");
                HasDied = true;

                Destroy(EnemyObject, 20f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerKnife"))
        {
            EnemyHealth -= 10;
            MyPlayer.Play();
            StabPlayer.Play();
        }
        if (other.gameObject.CompareTag("PlayerAxe"))
        {
            EnemyHealth -= 20;
            MyPlayer.Play();
            StabPlayer.Play();
        }
        if (other.gameObject.CompareTag("PlayerBat"))
        {
            EnemyHealth -= 15;
            MyPlayer.Play();
            StabPlayer.Play();
        }
    }
}
