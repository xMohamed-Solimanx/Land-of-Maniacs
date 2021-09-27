using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SaveScript.WifeFollowing)
        {
            StartCoroutine(LoadFinalScene());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (SaveScript.WifeFollowing)
        {
            StartCoroutine(LoadFinalScene());
        }
    }


    IEnumerator LoadFinalScene()
      {
         yield return new WaitForSeconds(0.1f);
         SceneManager.LoadScene(4);
     }


}
