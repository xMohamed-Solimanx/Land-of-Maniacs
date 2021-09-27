using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKeyRoom : MonoBehaviour
{
    public GameObject RoomKey;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
      //  StartCoroutine(StartElements());
    }

    

    void DropRoomKey()
    {
        Vector3 position = transform.position;
        GameObject key = Instantiate(RoomKey, position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
        key.gameObject.SetActive(true);

    }

   // IEnumerator StartElements()
  //  {
    //    yield return new WaitForSeconds(3f);
    //    RoomKey = SaveScript.RoomKeyy;
       // HouseKey.gameObject.SetActive(false);



  //  }

}
