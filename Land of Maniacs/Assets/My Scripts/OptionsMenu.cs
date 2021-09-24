using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject VisualsPanel;
    [SerializeField] GameObject SoundsPanel;
    [SerializeField] GameObject ControlsPanel;
    [SerializeField] GameObject DifficultyPanel;
    [SerializeField] GameObject SavePanel;
    [SerializeField] GameObject BackToMenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Time.timeScale = 0;

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
}

