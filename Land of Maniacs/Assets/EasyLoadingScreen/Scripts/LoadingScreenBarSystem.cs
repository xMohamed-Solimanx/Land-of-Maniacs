﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenBarSystem : MonoBehaviour {

    public GameObject bar;
    public Text loadingText;
    public bool backGroundImageAndLoop;
    public float LoopTime;
    public GameObject[] backgroundImages;
    [Range(0,1f)]public float vignetteEfectVolue; // Must be a value between 0 and 1
    AsyncOperation async;
    Image vignetteEfect;

    public GameObject MenuScreen;
    public GameObject LoadingScreen;


    public void loadingScreen (int sceneNo)
    {
        LoadingScreen.gameObject.SetActive(true);
        MenuScreen.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        StartCoroutine(Loading(sceneNo));
    }

    public void SwitchOff()
    {
        LoadingScreen.gameObject.SetActive(true);
        MenuScreen.gameObject.SetActive(false);
    }

    public void NewGame()
    {
        SaveScript.NewGame = true; //to force to reset to a new game
    }

    // Used to try. Delete the comment lines (25 and 36)
    /*
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bar.transform.localScale += new Vector3(0.001f,0,0);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");
        }
    }
    */

    private void Start()
    {
        Cursor.visible = true;
        vignetteEfect = transform.Find("VignetteEfect").GetComponent<Image>();
        vignetteEfect.color = new Color(vignetteEfect.color.r,vignetteEfect.color.g,vignetteEfect.color.b,vignetteEfectVolue);
        MenuScreen.gameObject.SetActive(true);
        //LoadingScreen.gameObject.SetActive(false);
        if (backGroundImageAndLoop)
            StartCoroutine(transitionImage());
    }


    // The pictures change according to the time of
    IEnumerator transitionImage ()
    {
        for (int i = 0; i < backgroundImages.Length; i++)
        {
            yield return new WaitForSeconds(LoopTime);
            for (int j = 0; j < backgroundImages.Length; j++)
                backgroundImages[j].SetActive(false);
            backgroundImages[i].SetActive(true);           
        }
    }

    // Activate the scene 
    IEnumerator Loading (int sceneNo)
    {
        async = SceneManager.LoadSceneAsync(sceneNo);
        async.allowSceneActivation = false;

        // Continue until the installation is completed
        while (async.isDone == false)
        {
            bar.transform.localScale = new Vector3(async.progress,0.9f,1);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");

            if (async.progress == 0.9f)
            {
                bar.transform.localScale = new Vector3(1, 0.9f, 1);
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
