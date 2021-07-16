using System.Collections;
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
