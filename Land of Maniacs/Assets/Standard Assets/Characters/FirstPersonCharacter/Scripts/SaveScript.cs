using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int PlayerHealth = 100;       //to be available for other scripts
    public static bool HealthChanged = false;
    public static float BatteryPower = 1.0f;
    public static bool BatteryRefill = false;
    public static bool FlashLightOn = false;
    public static bool NVLightOn = false;
    public static int Apples = 0;
    public static int Batteries = 0;
    public static bool Axe = false;
    public static bool Knife = false;
    public static bool BaseballBat = false;
    public static bool Handgun = false;
    public static bool Crossbow = false;
    public static bool CabinKey = false;
    public static bool HouseKey = false;
    public static bool RoomKey = false;
    public static int HandgunAmmo = 0;
    public static int CrossbowAmmo = 0;
    public static bool InventoryActive = false;
    public static bool OptionsActive = false;


    public static bool HaveKnife = false;
    public static bool HaveBat = false;
    public static bool HaveAxe = false;
    public static bool HaveGun = false;
    public static bool HaveCrossbow = false;

    public static int Bullets = 12;
    public static int Arrows = 10;

    public static bool NewGame = false;



    private void Start()
    {
        if (NewGame == true)
        {
            PlayerHealth = 100;       //to be available for other scripts
            HealthChanged = false;
            BatteryPower = 1.0f;
            BatteryRefill = false;
            FlashLightOn = false;
            NVLightOn = false;
            Apples = 0;
            Batteries = 0;
            Axe = false;
            Knife = false;
            BaseballBat = false;
            Handgun = false;
            Crossbow = false;
            CabinKey = false;
            HouseKey = false;
            RoomKey = false;
            HandgunAmmo = 0;
            CrossbowAmmo = 0;
            InventoryActive = false;

            HaveKnife = false;
            HaveBat = false;
            HaveAxe = false;
            HaveGun = false;
            HaveCrossbow = false;

            Bullets = 12;
            Arrows = 10;

        }
    }
}



