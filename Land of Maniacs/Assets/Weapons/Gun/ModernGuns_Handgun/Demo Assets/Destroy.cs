using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // this is a script created to dedstroy the infinte bullet casing that can be created
    // while firing the gun.

    [SerializeField] float DestroyTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    
}
