using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{

    [SerializeField] Image BatteryUI;
    [SerializeField] float DrainTime = 180.0f;
    [SerializeField] float Power;
   
   // void Start()
   // {
      //  BatteryUI.fillAmount = 0f;
   // }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.BatteryRefill == true) //used when player clicks on a battery in the inventory
        {
            SaveScript.BatteryRefill = false;
            BatteryUI.fillAmount = 1.0f;
            Power = BatteryUI.fillAmount;
            SaveScript.BatteryPower = Power;
        }
        if (SaveScript.FlashLightOn == true || SaveScript.NVLightOn == true)
        {
            BatteryUI.fillAmount -= 1.0f / DrainTime * Time.deltaTime;
            Power = BatteryUI.fillAmount;
            SaveScript.BatteryPower = Power;
        }
        

      //Debug.Log(SaveScript.BatteryPower);
    }
}
