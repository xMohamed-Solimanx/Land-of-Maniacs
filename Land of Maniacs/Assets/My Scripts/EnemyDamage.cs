using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    public int EnemyHealth = 100;
    private AudioSource MyPlayer;
    [SerializeField] AudioSource StabPlayer;
    private Animator Anim;

    [SerializeField] GameObject EnemyObject; //To destroy the enemy object after death

    public bool HasDied = false; //used in Update() so that the death animation doesn't loop

    [SerializeField] GameObject BloodSplatKnife; //to turn the blood effect coming out of the player's weapon on and off
    [SerializeField] GameObject BloodSplatAxe;
    [SerializeField] GameObject BloodSplatBat;

    private bool DamageOn = false; //used to delay the Update() untill the Coroutine (StartElements) is finished

    [SerializeField] bool IsBoss;

    private bool CrossbowDamage = false;


    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = GetComponent<AudioSource>();
        Anim = GetComponentInParent<Animator>();
        StartCoroutine(StartElements());

    }

    // Update is called once per frame
    void Update()
    {
        if (DamageOn == true)
        {

            if (IsBoss == false)
            {
                if (EnemyHealth <= 0)
                {
                    if (HasDied == false)
                    {
                        Anim.SetTrigger("Death");
                        HasDied = true;
                        Anim.SetBool("IsDead", true);

                        Destroy(this.transform.parent.gameObject, 10f);
                        SaveScript.EnemiesOnScreen--;


                    }
                }
            }

            if (IsBoss == true)
            {
                if (EnemyHealth <= 0)
                {
                    if (HasDied == false)
                    {
                        Anim.SetTrigger("BossDead");
                        HasDied = true;
                        // transform.gameObject.GetComponentInChildren<BossAttack>().enabled = false;
                        EnemyObject.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
                        EnemyObject.gameObject.GetComponentInChildren<BossAttack>().enabled = false;
                        EnemyObject.gameObject.GetComponentInChildren<BossShoots>().enabled = false;
                        EnemyObject.gameObject.GetComponentInChildren<EnemyDamage>().enabled = false;
                        EnemyObject.gameObject.GetComponentInChildren<BossAttack>().ChaseMusic.SetActive(false);
                        EnemyObject.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
                        EnemyObject.gameObject.GetComponentInChildren<SimpleShootBoss>().enabled = false;       //I then remembered i can access these components directly from the death animation
                        Destroy(this.transform.parent.gameObject, 5f);


                        // Debug.Log("SimpleShootBoss Disabled");



                        // Destroy(this.transform.parent.gameObject, 4f);

                        // StartCoroutine(LoadFinalScene());
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerKnife"))
        {
            EnemyHealth -= 25;
            MyPlayer.Play();
            StabPlayer.Play();
            BloodSplatKnife.gameObject.SetActive(true);

        }
        if (other.gameObject.CompareTag("PlayerAxe"))
        {
            EnemyHealth -= 30;
            MyPlayer.Play();
            StabPlayer.Play();
            BloodSplatAxe.gameObject.SetActive(true);

        }
        if (other.gameObject.CompareTag("PlayerBat"))
        {
            EnemyHealth -= 20;
            MyPlayer.Play();
            StabPlayer.Play();
            BloodSplatBat.gameObject.SetActive(true);

        }
        if (other.gameObject.CompareTag("PlayerCrossbow"))
        {
            if (CrossbowDamage == false)
            {
                CrossbowDamage = true;
                EnemyHealth -= 50;
                StartCoroutine(CrossbowReset());
                MyPlayer.Play();
                StabPlayer.Play();
                Destroy(other.gameObject, 0.5f);
                Debug.Log("Crossbow");
            }

        }
    }




    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);
        StabPlayer = SaveScript.StabSound;
        BloodSplatKnife = SaveScript.SplatKnife;
        BloodSplatBat = SaveScript.SplatBat;
        BloodSplatAxe = SaveScript.SplatAxe;

        BloodSplatKnife.gameObject.SetActive(false);
        BloodSplatAxe.gameObject.SetActive(false);
        BloodSplatBat.gameObject.SetActive(false);

        DamageOn = true;

    }

    IEnumerator CrossbowReset()
    {
        yield return new WaitForSeconds(0.6f);
        CrossbowDamage = false;
        Debug.Log("Crossbow is now false");
    }

   // IEnumerator LoadFinalScene()
  //  {
   //     yield return new WaitForSeconds(6f);
   //     SceneManager.LoadScene(4);
   // }

}
