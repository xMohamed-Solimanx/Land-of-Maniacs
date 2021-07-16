using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupsScript : MonoBehaviour
{

    RaycastHit hit;
    [SerializeField] float Distance = 4.0f;
    [SerializeField] GameObject PickupMSG;
    [SerializeField] GameObject BatteriesFullMSG;
    [SerializeField] GameObject ApplesFullMSG;
    private AudioSource MyPlayer;
    private float RayDistance;
    private bool CanSeePickup = false;
    private bool BatteriesFull = false;
    private bool ApplesFull = false;


    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = GetComponent<AudioSource>(); //Get audio source attached to this object

        PickupMSG.gameObject.SetActive(false);
        BatteriesFullMSG.gameObject.SetActive(false);
        ApplesFullMSG.gameObject.SetActive(false);
        RayDistance = Distance;
    }
    public float timetowait = 2f;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            if (hit.transform.tag == "Apple")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Apples == 6)
                    {
                        ApplesFull = true;
                    }
                    else
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Apples += 1;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Battery")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(SaveScript.Batteries == 4)
                    {
                        BatteriesFull = true;
                    }
                    else
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Batteries += 1;
                        MyPlayer.Play();
                    }

                }
            }
            else
            {
                CanSeePickup = false;
            }
        }

        if (CanSeePickup == true)
        {
            PickupMSG.gameObject.SetActive(true);
            RayDistance = 10000f;
        }
        if (CanSeePickup == false)
        {
            PickupMSG.gameObject.SetActive(false);
            RayDistance = Distance;

        }

        if (BatteriesFull == true)
        {
            BatteriesFullMSG.gameObject.SetActive(true);
            PickupMSG.gameObject.SetActive(false);
            StartCoroutine(BatteriesReset());
        }

        if (ApplesFull == true)
        {
            ApplesFullMSG.gameObject.SetActive(true);
            PickupMSG.gameObject.SetActive(false);
            StartCoroutine(ApplesReset());
        }



    }

   IEnumerator BatteriesReset()
   {
        yield return new WaitForSeconds(2);
        BatteriesFullMSG.gameObject.SetActive(false);
        BatteriesFull = false;
        
    }

    IEnumerator ApplesReset()
    {
        yield return new WaitForSeconds(2);
        ApplesFullMSG.gameObject.SetActive(false);
        ApplesFull = false;

    }

}
