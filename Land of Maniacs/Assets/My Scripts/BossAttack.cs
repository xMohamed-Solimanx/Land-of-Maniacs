using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossAttack : MonoBehaviour
{
    private NavMeshAgent Nav;
    private float DistanceToPlayer;
    [SerializeField] Transform Player;
    [SerializeField] GameObject Enemy;
    [SerializeField] Animator Anim;
    [SerializeField] float AttackRotateSpeed = 2.0f;
    public GameObject ChaseMusic;
    [SerializeField] GameObject HurtUI;

    [SerializeField] GameObject EnemyDamageZone; // to access HasDied bool to be able to turn off chase music after enemy death

    private AnimatorStateInfo BossInfo;

    [SerializeField] Transform ShootScript; // to turn off boss shooting when he is "hurt" (hit by player) "hurt is the tag of reactions animations"

    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponentInParent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        BossInfo = Anim.GetCurrentAnimatorStateInfo(0);
        DistanceToPlayer = Vector3.Distance(Player.position, Enemy.transform.position);


        if (BossInfo.IsTag("Chase"))
        {
            if (EnemyDamageZone.GetComponent<EnemyDamage>().HasDied == false) // if false, play the chase music
            {
                ChaseMusic.gameObject.SetActive(true);

                Nav.isStopped = false;          //start moving
                Nav.acceleration = 24;
                Nav.SetDestination(Player.position);
                HurtUI.gameObject.SetActive(false);
                ShootScript.GetComponent<SimpleShootBoss>().enabled = false;

            }

        }
        if (BossInfo.IsTag("Shoot"))
        {
            if (EnemyDamageZone.GetComponent<EnemyDamage>().HasDied == false) // if false, play the chase music
            {
                Nav.isStopped = true;

                Nav.acceleration = 180;         //The higher the acceleration, the enemy won't slide when stopping'
                HurtUI.gameObject.SetActive(true);

                Vector3 Pos = (Player.position - Enemy.transform.position).normalized;  //handling enemy rotation when attacking the player to make him face the player
                Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, PosRotation, Time.deltaTime * AttackRotateSpeed);
            }
        }

        if (BossInfo.IsTag("Hurt"))
        {
            ShootScript.GetComponent<SimpleShootBoss>().enabled = false;

        }
    }



    public void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("PlayerKnife"))
        {
            Anim.SetTrigger("SmallReact");
        }

        if (other.gameObject.CompareTag("PlayerAxe"))
        {
            Anim.SetTrigger("SmallReact");
        }

        if (other.gameObject.CompareTag("PlayerBat"))
        {
            Anim.SetTrigger("SmallReact");
        }
        if (other.gameObject.CompareTag("PlayerCrossbow"))
        {
            Anim.SetTrigger("BigReact");
        }
    }










}
