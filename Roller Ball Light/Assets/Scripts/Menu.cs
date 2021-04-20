using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject playGame, fases;

    public GameObject bgLoad;
    public Slider progressLoad;
    public GameObject all;

    public GameObject[] fasesLevel;

    void Start()
    {
        NextLevel.instance.contadorFases = PlayerPrefs.GetInt("contadorFases");
        Debug.Log(NextLevel.instance.contadorFases);

        for (int i=0; i < NextLevel.instance.contadorFases; i++)
        {
            fasesLevel[i].SetActive(true);
        }
    }

    public void PlayGame()
    {
        playGame.SetActive(false);
        fases.SetActive(true);
    }

    public void LoadLevel(int sceneIndex)
    {
        all.SetActive(false);
        StartCoroutine("LoadAsync", (sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        bgLoad.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressLoad.value = progress;

            yield return null;
        }

    }
}
