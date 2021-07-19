using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class LightSettingsPlayer : MonoBehaviour
{
    [SerializeField] PostProcessVolume MyVolume;
    [SerializeField] PostProcessProfile Standard;
    [SerializeField] PostProcessProfile NightVision;
    [SerializeField] GameObject NightVisionOverlay;
    [SerializeField] GameObject FlashlightObject;
    [SerializeField] GameObject EnemyFlashlight;


    private bool NightVisionActive = false;
    private bool FlashlightActive = false;

    public static bool InventoryOn = false;



    void Start()
    {
        FlashlightObject.gameObject.SetActive(false);
        EnemyFlashlight.gameObject.SetActive(false);
        NightVisionOverlay.gameObject.SetActive(false);
    }

    void Update()
    {
        if (SaveScript.BatteryPower > 0.0f) 
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (NightVisionActive == false)
                {
                    MyVolume.profile = NightVision;
                    NightVisionOverlay.gameObject.SetActive(true);
                    NightVisionActive = true;
                    SaveScript.NVLightOn = true;
                }
                 
                else
                {
                    MyVolume.profile = Standard;
                    NightVisionOverlay.gameObject.SetActive(false);
                    NightVisionActive = false;
                    SaveScript.NVLightOn = false;
                }

            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (FlashlightActive == false)
                {
                    FlashlightObject.gameObject.SetActive(true);
                    EnemyFlashlight.gameObject.SetActive(true);

                    FlashlightActive = true;
                    SaveScript.FlashLightOn = true;

                }
          
            else
            {
                    FlashlightObject.gameObject.SetActive(false);
                    EnemyFlashlight.gameObject.SetActive(false);
                    FlashlightActive = false;
                    SaveScript.FlashLightOn = false;
                }

            }
        }

        if(SaveScript.BatteryPower <= 0.0f) // Auto turn off NV and Flashlight when battery is drained
        {
            MyVolume.profile = Standard;
            NightVisionOverlay.gameObject.SetActive(false);
            NightVisionActive = false;
            SaveScript.NVLightOn = false;

            FlashlightObject.gameObject.SetActive(false);
            EnemyFlashlight.gameObject.SetActive(false);
            FlashlightActive = false;
            SaveScript.FlashLightOn = false;
        }
        
        if (InventoryOn == true)
        {
            MyVolume.profile = Standard;
            NightVisionOverlay.gameObject.SetActive(false);
            NightVisionActive = false;
            SaveScript.NVLightOn = false;

            FlashlightObject.gameObject.SetActive(false);
            EnemyFlashlight.gameObject.SetActive(false);
            FlashlightActive = false;
            SaveScript.FlashLightOn = false;
        }

    }//Update()
}
