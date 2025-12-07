using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        /*pantallaTransicion.gameObject.GetComponent<AlphaChangerPanelImage>().appear = true;

        pantallaTransicion.gameObject.GetComponent<AlphaChangerPanelImage>().tiempo = tiempo;

        pantallaTransicion.gameObject.GetComponent<AlphaChangerPanelImage>().AlphaChange(tiempo);

        pantallaTransicion.gameObject.GetComponent<AlphaChangerPanelImage>().appear = false;*/

        for (float i = 0; i <= tiempoTransicion; i += Time.deltaTime)
        {


            pantallaTransicion.GetComponent<UnityEngine.UI.Image>().color = new Color (0f,0f,0f,i/tiempoTransicion + 0.02f);

            var alpha = pantallaTransicion.GetComponent<UnityEngine.UI.Image>().color.a;

            pantallaTransicion.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RawImage>().color = new Color (255f,255f,255f,alpha);

            pantallaTransicion.transform.GetChild(0).GetChild(1).gameObject.GetComponent<RawImage>().color = new Color (255f,255f,255f,alpha);

            pantallaTransicion.transform.GetChild(0).GetChild(2).gameObject.GetComponent<RawImage>().color = new Color (255f,255f,255f,alpha);

            pantallaTransicion.transform.GetChild(0).GetChild(3).gameObject.GetComponent<RawImage>().color = new Color (255f,255f,255f,alpha);

            pantallaTransicion.transform.GetChild(0).GetChild(4).gameObject.GetComponent<RawImage>().color = new Color (255f,255f,255f,alpha);

            pantallaTransicion.transform.GetChild(0).GetChild(5).gameObject.GetComponent<RawImage>().color = new Color (255f,255f,255f,alpha);

            pantallaTransicion.transform.GetChild(0).GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().color = new Color (255f,255f,255f,alpha);

            pantallaTransicion.transform.GetChild(0).GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().color = new Color (255f,255f,255f,alpha);

            pantallaTransicion.transform.GetChild(0).GetChild(8).gameObject.GetComponent<TextMeshProUGUI>().color = new Color (255f,255f,255f,alpha);

            yield return new WaitForSeconds(0.002f); //este numero es 1 a 1 con Time.deltaTime, quiere decir
            // que puedo combinar un for como este y este WaitForSeconds para hacer bucles dependientes de
            //segundos

        }

        yield return new WaitForSeconds(0.01f);

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
