using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int HandgunAmmoNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckHandgunAmmo());
    }

   




    IEnumerator CheckHandgunAmmo()
    {
        yield return new WaitForSeconds(1);
        if (HandgunAmmoNumber > SaveScript.HandgunAmmoLeft)
        {
            Destroy(gameObject);
        }
    }


}
