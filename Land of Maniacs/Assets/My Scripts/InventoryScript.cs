using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
   
    [SerializeField] GameObject InventoryPanel;
    public static bool InventoryActive = false;

    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel.gameObject.SetActive(false);
        InventoryActive = false;
        Cursor.visible = false;
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
    }
}
