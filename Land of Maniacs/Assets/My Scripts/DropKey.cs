using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKey : MonoBehaviour
{
    public GameObject HouseKey;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartElements());
    }

    

    void DropCoin()
    {
        Vector3 position = transform.position;
        GameObject key = Instantiate(HouseKey, position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
        key.gameObject.SetActive(true);

    }

    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(3f);
        HouseKey = SaveScript.HouseKeyy;
       // HouseKey.gameObject.SetActive(false);



    }

}
