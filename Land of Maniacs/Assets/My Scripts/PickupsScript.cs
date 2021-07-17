using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupsScript : MonoBehaviour
{

    RaycastHit hit;
    [SerializeField] float Distance = 4.0f;

    [SerializeField] GameObject PickupMSG;
    [SerializeField] GameObject PickupAxeMSG;
    [SerializeField] GameObject PickupKnifeMSG;
    [SerializeField] GameObject PickupBaseballBatMSG;
    [SerializeField] GameObject PickupHandgunMSG;
    [SerializeField] GameObject PickupCrossbowMSG;
    [SerializeField] GameObject BatteriesFullMSG;
    [SerializeField] GameObject ApplesFullMSG;
    [SerializeField] GameObject HasWeaponMSG;

    private AudioSource MyPlayer;

    private float RayDistance;

    private bool CanSeePickup = false;
    private bool CanSeeAxe = false;
    private bool CanSeeKnife = false;
    private bool CanSeeBaseballBat = false;
    private bool CanSeeHandgun = false;
    private bool CanSeeCrossbow = false;

    private bool BatteriesFull = false;
    private bool ApplesFull = false;
    private bool HasWeapon = false;



    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = GetComponent<AudioSource>(); //Get audio source attached to this object

        PickupMSG.gameObject.SetActive(false);
        BatteriesFullMSG.gameObject.SetActive(false);
        ApplesFullMSG.gameObject.SetActive(false);
        HasWeaponMSG.gameObject.SetActive(false);
        PickupAxeMSG.gameObject.SetActive(false);
        PickupKnifeMSG.gameObject.SetActive(false);
        PickupBaseballBatMSG.gameObject.SetActive(false);
        PickupHandgunMSG.gameObject.SetActive(false);
        BatteriesFullMSG.gameObject.SetActive(false);
        RayDistance = Distance;
    }
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
            else if (hit.transform.tag == "Axe")
            {
                CanSeeAxe = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Axe == true)
                    {
                        HasWeapon = true;
                    }
                    else
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Axe = true;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Knife")
            {
                CanSeeKnife = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Knife == true)
                    {
                        HasWeapon = true;
                    }
                    else
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Knife = true;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "BaseballBat")
            {
                CanSeeBaseballBat = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.BaseballBat == true)
                    {
                        HasWeapon = true;
                    }
                    else
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.BaseballBat = true;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Crossbow")
            {
                CanSeeCrossbow = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Crossbow == true)
                    {
                        HasWeapon = true;
                    }
                    else
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Crossbow = true;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Handgun")
            {
                CanSeeHandgun = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Handgun == true)
                    {
                        HasWeapon = true;
                    }
                    else
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Handgun = true;
                        MyPlayer.Play();
                    }
                }
            }
            else
            {
                CanSeePickup = false;
                CanSeeAxe = false;
                CanSeeKnife = false;
                CanSeeBaseballBat = false;
                CanSeeHandgun = false;
                CanSeeCrossbow = false;
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

        if (CanSeeAxe == true)
        {
            PickupAxeMSG.gameObject.SetActive(true);
            RayDistance = 10000f;
        }
        if (CanSeeAxe == false)
        {
            PickupAxeMSG.gameObject.SetActive(false);
            RayDistance = Distance;

        }

        if (CanSeeKnife == true)
        {
            PickupKnifeMSG.gameObject.SetActive(true);
            RayDistance = 10000f;
        }
        if (CanSeeKnife == false)
        {
            PickupKnifeMSG.gameObject.SetActive(false);
            RayDistance = Distance;

        }

        if (CanSeeBaseballBat == true)
        {
            PickupBaseballBatMSG.gameObject.SetActive(true);
            RayDistance = 10000f;
        }
        if (CanSeeBaseballBat == false)
        {
            PickupBaseballBatMSG.gameObject.SetActive(false);
            RayDistance = Distance;

        }
        if (CanSeeHandgun == true)
        {
            PickupHandgunMSG.gameObject.SetActive(true);
            RayDistance = 10000f;
        }
        if (CanSeeHandgun == false)
        {
            PickupHandgunMSG.gameObject.SetActive(false);
            RayDistance = Distance;

        }

        if (CanSeeCrossbow == true)
        {
            PickupCrossbowMSG.gameObject.SetActive(true);
            RayDistance = 10000f;
        }
        if (CanSeeCrossbow == false)
        {
            PickupCrossbowMSG.gameObject.SetActive(false);
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

        if (HasWeapon == true)
        {
            HasWeaponMSG.gameObject.SetActive(true);
            PickupMSG.gameObject.SetActive(false);
            StartCoroutine(WeaponReset());
        }

    }

    IEnumerator WeaponReset()
    {
        yield return new WaitForSeconds(2);
        HasWeaponMSG.gameObject.SetActive(false);
        HasWeapon = false;

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
