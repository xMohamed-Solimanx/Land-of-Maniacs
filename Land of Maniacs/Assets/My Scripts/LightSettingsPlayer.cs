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

    private bool NightVisionActive = false;
    private bool FlashlightActive = false;


    void Start()
    {
        FlashlightObject.gameObject.SetActive(false);
        NightVisionOverlay.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (NightVisionActive == false)
            {
                MyVolume.profile = NightVision;
                NightVisionOverlay.gameObject.SetActive(true);
                NightVisionActive = true;
            }
            else
            {
                MyVolume.profile = Standard;
                NightVisionOverlay.gameObject.SetActive(false);
                NightVisionActive = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightActive == false)
            {
                FlashlightObject.gameObject.SetActive(true);
                FlashlightActive = true;
            }
            else
            {
                FlashlightObject.gameObject.SetActive(false);
                FlashlightActive = false;
            }

        }



    }
}
