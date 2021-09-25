using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrossbowPickup : MonoBehaviour
{
    [SerializeField] int CrossbowAmmoNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckCrossbowAmmo());
    }

   




    IEnumerator CheckCrossbowAmmo()
    {
        yield return new WaitForSeconds(1);
        if (CrossbowAmmoNumber > SaveScript.CrossbowAmmoLeft)
        {
            Destroy(gameObject);
        }
    }


}
