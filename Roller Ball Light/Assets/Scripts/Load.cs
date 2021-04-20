using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public static Load instance;

    public GameObject bgLoad;
    public Slider progressLoad;
    public Toggle cameraFixa;

    public GameObject menu, subMenu, subConfig, all;

    public int configCamera;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        Time.timeScale = 1;
        configCamera = PlayerPrefs.GetInt("configCamera");

        if (configCamera == 1)
        {
            cameraFixa.isOn = true;
            Ball.instance.camLookat = true;
            
        }
        else
        {
            cameraFixa.isOn = false;
            Ball.instance.camLookat = false;
           
        }
    }

    public void LoadLevel( int sceneIndex)
    {
        all.SetActive(false);
        StartCoroutine("LoadAsync", (sceneIndex));
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Config()
    {
        subMenu.SetActive(false);
        subConfig.SetActive(true);
    }

    public void Voltar()
    {
        subConfig.SetActive(false);
        subMenu.SetActive(true);
    }
    public void Toggle()
    {
        Ball.instance.camLookat = !Ball.instance.camLookat;

        if (Ball.instance.camLookat == true)
        {
            
            configCamera = 1;
            PlayerPrefs.SetInt("configCamera", configCamera);
        }
        else
        {
            
            configCamera = 0;
            PlayerPrefs.SetInt("configCamera", configCamera);
        }
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        bgLoad.SetActive(true);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressLoad.value = progress;

            yield return null;
        }

    }
}
