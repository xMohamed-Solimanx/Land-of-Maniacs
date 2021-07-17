﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
   
    [SerializeField] GameObject InventoryPanel;
    [SerializeField] GameObject HealthFullMSG;
    private AudioSource MyPlayer;
    [SerializeField] AudioClip AppleBite;
    [SerializeField] AudioClip BatteryPickup;
    public static bool InventoryActive = false;
    //public static float delay = 2f;

    // Apples
    [SerializeField] GameObject AppleImage1;
    [SerializeField] GameObject AppleButton1;

    [SerializeField] GameObject AppleImage2;
    [SerializeField] GameObject AppleButton2;

    [SerializeField] GameObject AppleImage3;
    [SerializeField] GameObject AppleButton3;

    [SerializeField] GameObject AppleImage4;
    [SerializeField] GameObject AppleButton4;

    [SerializeField] GameObject AppleImage5;
    [SerializeField] GameObject AppleButton5;

    [SerializeField] GameObject AppleImage6;
    [SerializeField] GameObject AppleButton6;


    // Batteries
    [SerializeField] GameObject BatteryImage1;
    [SerializeField] GameObject BatteryButton1;

    [SerializeField] GameObject BatteryImage2;
    [SerializeField] GameObject BatteryButton2;

    [SerializeField] GameObject BatteryImage3;
    [SerializeField] GameObject BatteryButton3;

    [SerializeField] GameObject BatteryImage4;
    [SerializeField] GameObject BatteryButton4;

    // Weapons

    [SerializeField] GameObject KnifeImage;
    [SerializeField] GameObject KnifeButton;

    [SerializeField] GameObject BatImage;
    [SerializeField] GameObject BatButton;

    [SerializeField] GameObject AxeImage;
    [SerializeField] GameObject AxeButton;

    [SerializeField] GameObject HandgunImage;
    [SerializeField] GameObject HandgunButton;

    [SerializeField] GameObject CrossbowImage;
    [SerializeField] GameObject CrossbowButton;

    // Ammo

    [SerializeField] GameObject HandgunAmmoImage1;
    [SerializeField] GameObject HandgunAmmoButton1;

    [SerializeField] GameObject HandgunAmmoImage2;
    [SerializeField] GameObject HandgunAmmoButton2;

    [SerializeField] GameObject HandgunAmmoImage3;
    [SerializeField] GameObject HandgunAmmoButton3;

    [SerializeField] GameObject HandgunAmmoImage4;
    [SerializeField] GameObject HandgunAmmoButton4;

    [SerializeField] GameObject CrossbowAmmoImage;
    [SerializeField] GameObject CrossbowAmmoButton;

    // Keys

    [SerializeField] GameObject CabinKeyImage;

    [SerializeField] GameObject HouseKeyImage;

    [SerializeField] GameObject RoomKeyImage;



    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = GetComponent<AudioSource>(); //Get audio source attached to this object

        InventoryPanel.gameObject.SetActive(false);
        InventoryActive = false;
        Cursor.visible = false;

        // Apples
        AppleImage1.gameObject.SetActive(false);
        AppleButton1.gameObject.SetActive(false);
        AppleImage2.gameObject.SetActive(false);
        AppleButton2.gameObject.SetActive(false);
        AppleImage3.gameObject.SetActive(false);
        AppleButton3.gameObject.SetActive(false);
        AppleImage4.gameObject.SetActive(false);
        AppleButton4.gameObject.SetActive(false);
        AppleImage5.gameObject.SetActive(false);
        AppleButton5.gameObject.SetActive(false);
        AppleImage6.gameObject.SetActive(false);
        AppleButton6.gameObject.SetActive(false);

        // Batteries
        BatteryImage1.gameObject.SetActive(false);
        BatteryButton1.gameObject.SetActive(false);
        BatteryImage2.gameObject.SetActive(false);
        BatteryButton2.gameObject.SetActive(false);
        BatteryImage3.gameObject.SetActive(false);
        BatteryButton3.gameObject.SetActive(false);
        BatteryImage4.gameObject.SetActive(false);
        BatteryButton4.gameObject.SetActive(false);

        // Weapons

        KnifeImage.gameObject.SetActive(false);
        KnifeButton.gameObject.SetActive(false);
        BatImage.gameObject.SetActive(false);
        BatButton.gameObject.SetActive(false);
        AxeImage.gameObject.SetActive(false);
        AxeButton.gameObject.SetActive(false);
        HandgunImage.gameObject.SetActive(false);
        HandgunButton.gameObject.SetActive(false);
        CrossbowImage.gameObject.SetActive(false);
        CrossbowButton.gameObject.SetActive(false);

        // Ammo

        HandgunAmmoImage1.gameObject.SetActive(false);
        HandgunAmmoButton1.gameObject.SetActive(false);
        HandgunAmmoImage2.gameObject.SetActive(false);
        HandgunAmmoButton2.gameObject.SetActive(false);
        HandgunAmmoImage3.gameObject.SetActive(false);
        HandgunAmmoButton3.gameObject.SetActive(false);
        HandgunAmmoImage4.gameObject.SetActive(false);
        HandgunAmmoButton4.gameObject.SetActive(false);
        CrossbowAmmoImage.gameObject.SetActive(false);
        CrossbowAmmoButton.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryActive == false)
            {
                InventoryPanel.gameObject.SetActive(true);
                LightSettingsPlayer.InventoryOn = true;
                InventoryActive = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
            }
            else
            {
                InventoryPanel.gameObject.SetActive(false);
                LightSettingsPlayer.InventoryOn = false;
                InventoryActive = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
            }

        }

        CheckInventory();
        CheckWeapons();
        CheckAmmo();
        CheckKeys();
    }

    void CheckInventory()
    {
        // Apples
        if(SaveScript.Apples == 0)
        {
            AppleImage1.gameObject.SetActive(false);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(false);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(false);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(false);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(false);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 1)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(true);
            AppleImage2.gameObject.SetActive(false);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(false);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(false);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(false);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 2)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(true);
            AppleButton2.gameObject.SetActive(true);
            AppleImage3.gameObject.SetActive(false);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(false);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(false);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 3)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(true);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(true);
            AppleButton3.gameObject.SetActive(true);
            AppleImage4.gameObject.SetActive(false);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(false);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 4)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(true);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(true);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(true);
            AppleButton4.gameObject.SetActive(true);
            AppleImage5.gameObject.SetActive(false);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 5)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(true);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(true);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(true);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(true);
            AppleButton5.gameObject.SetActive(true);
            AppleImage6.gameObject.SetActive(false);
            AppleButton6.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 6)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(false);
            AppleImage2.gameObject.SetActive(true);
            AppleButton2.gameObject.SetActive(false);
            AppleImage3.gameObject.SetActive(true);
            AppleButton3.gameObject.SetActive(false);
            AppleImage4.gameObject.SetActive(true);
            AppleButton4.gameObject.SetActive(false);
            AppleImage5.gameObject.SetActive(true);
            AppleButton5.gameObject.SetActive(false);
            AppleImage6.gameObject.SetActive(true);
            AppleButton6.gameObject.SetActive(true);
        }



        // Batteries
        if (SaveScript.Batteries == 0)
        {
            BatteryImage1.gameObject.SetActive(false);
            BatteryButton1.gameObject.SetActive(false);
            BatteryImage2.gameObject.SetActive(false);
            BatteryButton2.gameObject.SetActive(false);
            BatteryImage3.gameObject.SetActive(false);
            BatteryButton3.gameObject.SetActive(false);
            BatteryImage4.gameObject.SetActive(false);
            BatteryButton4.gameObject.SetActive(false);
        }
        if (SaveScript.Batteries == 1)
        {
            BatteryImage1.gameObject.SetActive(true);
            BatteryButton1.gameObject.SetActive(true);
            BatteryImage2.gameObject.SetActive(false);
            BatteryButton2.gameObject.SetActive(false);
            BatteryImage3.gameObject.SetActive(false);
            BatteryButton3.gameObject.SetActive(false);
            BatteryImage4.gameObject.SetActive(false);
            BatteryButton4.gameObject.SetActive(false);
        }
        if (SaveScript.Batteries == 2)
        {
            BatteryImage1.gameObject.SetActive(true);
            BatteryButton1.gameObject.SetActive(false);
            BatteryImage2.gameObject.SetActive(true);
            BatteryButton2.gameObject.SetActive(true);
            BatteryImage3.gameObject.SetActive(false);
            BatteryButton3.gameObject.SetActive(false);
            BatteryImage4.gameObject.SetActive(false);
            BatteryButton4.gameObject.SetActive(false);
        }
        if (SaveScript.Batteries == 3)
        {
            BatteryImage1.gameObject.SetActive(true);
            BatteryButton1.gameObject.SetActive(false);
            BatteryImage2.gameObject.SetActive(true);
            BatteryButton2.gameObject.SetActive(false);
            BatteryImage3.gameObject.SetActive(true);
            BatteryButton3.gameObject.SetActive(true);
            BatteryImage4.gameObject.SetActive(false);
            BatteryButton4.gameObject.SetActive(false);
        }
        if (SaveScript.Batteries == 4)
        {
            BatteryImage1.gameObject.SetActive(true);
            BatteryButton1.gameObject.SetActive(false);
            BatteryImage2.gameObject.SetActive(true);
            BatteryButton2.gameObject.SetActive(false);
            BatteryImage3.gameObject.SetActive(true);
            BatteryButton3.gameObject.SetActive(false);
            BatteryImage4.gameObject.SetActive(true);
            BatteryButton4.gameObject.SetActive(true);
        } 
    }

    void CheckWeapons()
    {
        if (SaveScript.Knife)
        {
            KnifeImage.gameObject.SetActive(true);
            KnifeButton.gameObject.SetActive(true);
        }
        if (SaveScript.BaseballBat)
        {
            BatImage.gameObject.SetActive(true);
            BatButton.gameObject.SetActive(true);
        }
        if (SaveScript.Axe)
        {
            AxeImage.gameObject.SetActive(true);
            AxeButton.gameObject.SetActive(true);
        }
        if (SaveScript.Handgun)
        {
            HandgunImage.gameObject.SetActive(true);
            HandgunButton.gameObject.SetActive(true);
        }
        if (SaveScript.Crossbow)
        {
            CrossbowImage.gameObject.SetActive(true);
            CrossbowButton.gameObject.SetActive(true);
        }

    }

    void CheckAmmo()
    {
        if (SaveScript.HandgunAmmo == 0)
        {
            HandgunAmmoImage1.gameObject.SetActive(false);
            HandgunAmmoButton1.gameObject.SetActive(false);
            HandgunAmmoImage2.gameObject.SetActive(false);
            HandgunAmmoButton2.gameObject.SetActive(false);
            HandgunAmmoImage3.gameObject.SetActive(false);
            HandgunAmmoButton3.gameObject.SetActive(false);
            HandgunAmmoImage4.gameObject.SetActive(false);
            HandgunAmmoButton4.gameObject.SetActive(false);
        }
        if (SaveScript.HandgunAmmo == 1)
        {
            HandgunAmmoImage1.gameObject.SetActive(true);
            HandgunAmmoButton1.gameObject.SetActive(true);
            HandgunAmmoImage2.gameObject.SetActive(false);
            HandgunAmmoButton2.gameObject.SetActive(false);
            HandgunAmmoImage3.gameObject.SetActive(false);
            HandgunAmmoButton3.gameObject.SetActive(false);
            HandgunAmmoImage4.gameObject.SetActive(false);
            HandgunAmmoButton4.gameObject.SetActive(false);
        }
        if (SaveScript.HandgunAmmo == 2)
        {
            HandgunAmmoImage1.gameObject.SetActive(true);
            HandgunAmmoButton1.gameObject.SetActive(false);
            HandgunAmmoImage2.gameObject.SetActive(true);
            HandgunAmmoButton2.gameObject.SetActive(true);
            HandgunAmmoImage3.gameObject.SetActive(false);
            HandgunAmmoButton3.gameObject.SetActive(false);
            HandgunAmmoImage4.gameObject.SetActive(false);
            HandgunAmmoButton4.gameObject.SetActive(false);
        }
        if (SaveScript.HandgunAmmo == 3)
        {
            HandgunAmmoImage1.gameObject.SetActive(true);
            HandgunAmmoButton1.gameObject.SetActive(false);
            HandgunAmmoImage2.gameObject.SetActive(true);
            HandgunAmmoButton2.gameObject.SetActive(false);
            HandgunAmmoImage3.gameObject.SetActive(true);
            HandgunAmmoButton3.gameObject.SetActive(true);
            HandgunAmmoImage4.gameObject.SetActive(false);
            HandgunAmmoButton4.gameObject.SetActive(false);
        }
        if (SaveScript.HandgunAmmo == 4)
        {
            HandgunAmmoImage1.gameObject.SetActive(true);
            HandgunAmmoButton1.gameObject.SetActive(false);
            HandgunAmmoImage2.gameObject.SetActive(true);
            HandgunAmmoButton2.gameObject.SetActive(false);
            HandgunAmmoImage3.gameObject.SetActive(true);
            HandgunAmmoButton3.gameObject.SetActive(false);
            HandgunAmmoImage4.gameObject.SetActive(true);
            HandgunAmmoButton4.gameObject.SetActive(true);
        }

        if (SaveScript.CrossbowAmmo == 0)
        {
            CrossbowAmmoImage.gameObject.SetActive(false);
            CrossbowAmmoButton.gameObject.SetActive(false);
            
        }

        if (SaveScript.CrossbowAmmo == 1)
        {
            CrossbowAmmoImage.gameObject.SetActive(true);
            CrossbowAmmoButton.gameObject.SetActive(true);
            
        }
    }

    void CheckKeys()
    {
        if (!SaveScript.CabinKey)
        {
            CabinKeyImage.gameObject.SetActive(false);

        }

        if (SaveScript.CabinKey)
        {
            CabinKeyImage.gameObject.SetActive(true);
        }

        if (!SaveScript.HouseKey)
        {
            HouseKeyImage.gameObject.SetActive(false);

        }

        if (SaveScript.HouseKey)
        {
            HouseKeyImage.gameObject.SetActive(true);
        }

        if (!SaveScript.RoomKey)
        {
            RoomKeyImage.gameObject.SetActive(false);

        }

        if (SaveScript.RoomKey)
        {
            RoomKeyImage.gameObject.SetActive(true);
        }
    }
    void HealthUpdate() //used when player clicks on a Apple in the inventory
    {
        if (SaveScript.PlayerHealth == 100)
        {

            HealthFullMSG.gameObject.SetActive(true);
            StartCoroutine(HealthFull());
        }
        else if (SaveScript.PlayerHealth >= 91 && SaveScript.PlayerHealth <= 99)
        {
            MyPlayer.clip = AppleBite;
            MyPlayer.Play();
            SaveScript.Apples -= 1;
            SaveScript.PlayerHealth = 100;
            SaveScript.HealthChanged = true;
        }
        else
        {
            MyPlayer.clip = AppleBite;
            MyPlayer.Play();
            SaveScript.Apples -= 1;
            SaveScript.PlayerHealth += 10;
            SaveScript.HealthChanged = true;
        }

    }

    
    IEnumerator HealthFull()
    {
        yield return new WaitForSeconds(1);
        HealthFullMSG.gameObject.SetActive(false);
        
    }

    public void BatteryUpdate()  //used when player clicks on a battery in the inventory
    {
        MyPlayer.clip = BatteryPickup;
        MyPlayer.Play();
        SaveScript.BatteryRefill = true;
        SaveScript.Batteries -= 1;
       // BatteryPower.BatteryUI.fillAmount = 1f;

    }

}
