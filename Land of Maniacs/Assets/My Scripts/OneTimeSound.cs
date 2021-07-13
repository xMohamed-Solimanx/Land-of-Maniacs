using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeSound : MonoBehaviour
{
    private AudioSource OneTime;
    private Collider Collider;
    [SerializeField] bool isOneTime = false;
    [SerializeField] float PauseTime = 5.0f;



    // Start is called before the first frame update
    void Start()
    {
        OneTime = GetComponent<AudioSource>();
        Collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    { 
    if(other.CompareTag("Player"))
        {
            OneTime.Play();
            Collider.enabled = false;

            if(isOneTime == false)
            {
                StartCoroutine(Reset());
            }
        }
    else
        {
            Destroy(gameObject, PauseTime);
        }

    IEnumerator Reset()
        {
            yield return new WaitForSeconds(PauseTime);
            Collider.enabled = true;
        }
    }

}
