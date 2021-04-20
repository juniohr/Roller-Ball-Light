using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public static NextLevel instance;

    public int cena, contadorFases;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
       contadorFases = PlayerPrefs.GetInt("contadorFases");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cena > contadorFases)
            {
                contadorFases = cena;
                PlayerPrefs.SetInt("contadorFases", contadorFases);
                Debug.Log("cena é maior que contador");
            }
            Propagandas.instancia.Teste();
            Load.instance.LoadLevel(cena);
        }
    }
}
