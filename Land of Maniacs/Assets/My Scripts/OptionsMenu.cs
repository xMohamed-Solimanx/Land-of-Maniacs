using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing; //to access postprocessing layer to turn on or off Fog



public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject VisualsPanel;
    [SerializeField] GameObject SoundsPanel;
    [SerializeField] GameObject ControlsPanel;
    [SerializeField] GameObject DifficultyPanel;
    [SerializeField] GameObject SavePanel;
    [SerializeField] GameObject BackToMenuPanel;
    [SerializeField] PostProcessLayer MyLayer;
    [SerializeField] GameObject FogStorm;


    public Slider LightSlider; // to control brightness
    public Toggle FogToggle; //to turn on and off the fog
    private bool FogOn = true;

    public Toggle AntiOff;
    public Toggle AntiFXAA;
    public Toggle AntiSMAA;
    public Toggle AntiTAA;
    private int AntiState = 4;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;

        VisualsPanel.gameObject.SetActive(true);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
    }



    public void Visuals()
    {
        VisualsPanel.gameObject.SetActive(true);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Sounds()
    {
        VisualsPanel.gameObject.SetActive(false);
        SoundsPanel.gameObject.SetActive(true);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Controls()
    {
        VisualsPanel.gameObject.SetActive(false);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(true);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Difficulty()
    {
        VisualsPanel.gameObject.SetActive(false);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(true);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Save()
    {
        VisualsPanel.gameObject.SetActive(false);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(true);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        VisualsPanel.gameObject.SetActive(false);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(true);
    }


    public void LightValue() // to control brightness
    {
        RenderSettings.ambientIntensity = LightSlider.value;
    }

    public void FogState() // to control fog
    {
        
       if (FogToggle.isOn == true)
       {
                if (FogOn == true)
                {
                    MyLayer.fog.enabled = false;
                    FogStorm.gameObject.SetActive(false);
                    FogOn = false;
                }
                else if (FogOn == false)
                {
                    MyLayer.fog.enabled = true;
                    FogStorm.gameObject.SetActive(true);
                    FogOn = true;
                }
       }

        if (FogToggle.isOn == false)
        {
            if (FogOn == true)
            {
                MyLayer.fog.enabled = false;
                FogStorm.gameObject.SetActive(false);
                FogOn = false;
            }
            else if (FogOn == false)
            {
                MyLayer.fog.enabled = true;
                FogStorm.gameObject.SetActive(true);
                FogOn = true;
            }
        }

    }

    public void AntiAliasingOff()
    {
        if(AntiState != 1)
        {
            if(AntiOff.isOn == true)
            {
                MyLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
                AntiFXAA.isOn = false;
                AntiSMAA.isOn = false;
                AntiTAA.isOn = false;
                AntiState = 1;
            }
        }
    }

    public void AntiAliasingFXAA()
    {
        if (AntiState != 2)
        {
            if (AntiFXAA.isOn == true)
            {
                MyLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                AntiOff.isOn = false;
                AntiSMAA.isOn = false;
                AntiTAA.isOn = false;
                AntiState = 2;
            }
        }
    }
    public void AntiAliasingSMAA()
    {
        if (AntiState != 3)
        {
            if (AntiSMAA.isOn == true)
            {
                MyLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
                AntiOff.isOn = false;
                AntiFXAA.isOn = false;
                AntiTAA.isOn = false;
                AntiState = 3;
            }
        }
    }
    public void AntiAliasingTAA()
    {
        if (AntiState != 4)
        {
            if (AntiTAA.isOn == true)
            {
                MyLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
                AntiOff.isOn = false;
                AntiFXAA.isOn = false;
                AntiSMAA.isOn = false;
                AntiState = 4;
            }
        }
    }
}

