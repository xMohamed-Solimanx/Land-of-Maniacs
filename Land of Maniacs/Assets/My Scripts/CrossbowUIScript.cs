using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossbowUIScript : MonoBehaviour
{
    [SerializeField] Text ArrowsAmt;
    // Start is called before the first frame update
    void Start()
    {
        ArrowsAmt.text = SaveScript.Arrows + "";
    }

    // Update is called once per frame
    void Update()
    {
        ArrowsAmt.text = SaveScript.Arrows + "";

        if (SaveScript.HaveCrossbow)
        {
            if (SaveScript.InventoryOpen == false && SaveScript.OptionsOpen == false)
            {


                if (Input.GetKey(KeyCode.Mouse1))
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {

                        if (SaveScript.Arrows > 0)
                        {
                            SaveScript.Arrows -= 1;
                            // BulletAmt.text = SaveScript.Bullets + "";

                        }
                    }
                }
            }

        }
    }
}
