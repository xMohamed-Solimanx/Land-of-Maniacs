using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// Scrpt used to switch from Soly Studios to Main Menu
public class LoadMainMenu : MonoBehaviour
{
    [SerializeField] int LevelNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(LevelNumber);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(LevelNumber);

    }
}
