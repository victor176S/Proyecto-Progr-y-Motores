using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsUtilities : MonoBehaviour
{
    public static int sceneNumber;

    public GameObject options;

    public GameObject menuPrincipal;

    public float tiempoTransicion;

    public float tiempoCambioEscena;

    public GameObject pantallaTransicion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void ExitGame()
    {

        Application.Quit();

    }

    public void ChangeScene(int sceneNumber)
    {

        StartCoroutine(Transition(sceneNumber));

    }

    public IEnumerator Transition(int sceneNumber)
    {

        pantallaTransicion.transform.parent.gameObject.SetActive(true);

        StartCoroutine(pantallaTransicion.GetComponent<AlphaChangerV2>().AlphaChanger());
        yield return new WaitForSeconds(5f);

        StartCoroutine(SceneChangeTimeWait(sceneNumber));
    }

    public IEnumerator SceneChangeTimeWait(int sceneNumber)
    {

        yield return new WaitForSeconds(tiempoCambioEscena);

        SceneManager.LoadScene(sceneNumber);

    }

    public void OptionsGenericOpen()
    {
        menuPrincipal.gameObject.SetActive(false);
        options.gameObject.SetActive(true);
       
    }
    
    public void OptionsGenericClose()
    {
        menuPrincipal.gameObject.SetActive(true);
        options.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
