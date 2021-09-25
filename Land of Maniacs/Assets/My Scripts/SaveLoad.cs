﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public int DataExists = 10;
    [SerializeField] GameObject LoadButton;

    // Start is called before the first frame update
    void Start()
    {
        if (LoadButton != null)
        {
            LoadButton.gameObject.SetActive(false);
            DataExists = PlayerPrefs.GetInt("PlayersHealth", 0);
            if (DataExists > 0)
            {
                LoadButton.gameObject.SetActive(true);
            }
        }
        
    }

    

    public void LoadGameData()
    {
        SaveScript.SavedGame = true;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("PlayersHealth", SaveScript.PlayerHealth);
        PlayerPrefs.SetFloat("BatteriesPower", SaveScript.BatteryPower);
        PlayerPrefs.SetInt("ApplesAmt", SaveScript.Apples);
        PlayerPrefs.SetInt("BatteriesAmt", SaveScript.Batteries);
        PlayerPrefs.SetInt("HandgunAmmo", SaveScript.HandgunAmmo);
        PlayerPrefs.SetInt("CrossbowAmmo", SaveScript.CrossbowAmmo);
        PlayerPrefs.SetInt("BulletsAmt", SaveScript.Bullets);
        PlayerPrefs.SetInt("ArrowsAmt", SaveScript.Arrows);
        PlayerPrefs.SetInt("MaxEScreen", SaveScript.MaxEnemiesOnScreen);
        PlayerPrefs.SetInt("MaxEGame", SaveScript.MaxEnemiesInGame);
        PlayerPrefs.SetInt("ApplesL", SaveScript.ApplesLeft);
        PlayerPrefs.SetInt("HandgunAmmoL", SaveScript.HandgunAmmoLeft);
        PlayerPrefs.SetInt("BatteriesL", SaveScript.BatteriesLeft);
        PlayerPrefs.SetInt("CrossbowAmmoL", SaveScript.CrossbowAmmoLeft);

        PlayerPrefs.SetInt("Enemy1Alive", SaveScript.Enemy1);
        PlayerPrefs.SetInt("Enemy2Alive", SaveScript.Enemy2);
        PlayerPrefs.SetInt("Enemy3Alive", SaveScript.Enemy3);
        PlayerPrefs.SetInt("Enemy4Alive", SaveScript.Enemy4);
        PlayerPrefs.SetInt("Enemy5Alive", SaveScript.Enemy5);


        if (SaveScript.Knife == true)
        {
            PlayerPrefs.SetInt("KnifeInv", 1);
        }
        if (SaveScript.Axe == true)
        {
            PlayerPrefs.SetInt("AxeInv", 1);
        }
        if (SaveScript.BaseballBat == true)
        {
            PlayerPrefs.SetInt("BaseballBatInv", 1);
        }
        if (SaveScript.Handgun == true)
        {
            PlayerPrefs.SetInt("HandgunInv", 1);
        }
        if (SaveScript.Crossbow == true)
        {
            PlayerPrefs.SetInt("CrossbowInv", 1);
        }
        if (SaveScript.CabinKey == true)
        {
            PlayerPrefs.SetInt("CabinKeyK", 1);
        }
        if (SaveScript.HouseKey == true)
        {
            PlayerPrefs.SetInt("HouseK", 1);
        }
        if (SaveScript.RoomKey == true)
        {
            PlayerPrefs.SetInt("RoomK", 1);
        }
        


    }
}
