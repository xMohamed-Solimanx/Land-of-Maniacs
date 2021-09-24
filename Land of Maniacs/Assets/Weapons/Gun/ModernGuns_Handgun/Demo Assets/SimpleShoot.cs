using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{

    //public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    public AudioSource GunShotPlayer;

   // public float shotPower = 100f;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        if (SaveScript.Bullets > 0)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GetComponent<Animator>().SetTrigger("Fire");
                }
            }
        }
        
      //      if (Input.GetButtonDown("Fire1"))
     //   {
         //   GetComponent<Animator>().SetTrigger("Fire");
       // }
    }

    void Shoot()
    {
        

        GameObject tempFlash;
      // Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
       tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

       // Destroy(tempFlash, 0.5f);
        //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);
       if (SaveScript.Bullets >= 0)
        {
            GunShotPlayer.Play();
            SaveScript.Bullets -= 1;

        }
    }

    void CasingRelease()
    {
         GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
