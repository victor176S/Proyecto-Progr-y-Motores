using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaMuerteEventos : MonoBehaviour
{

    public int nivel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (nivel == 1)
        StartCoroutine(MuerteEventos1());

        if(nivel == 2)
        StartCoroutine(MuerteEventos2());

        if(nivel == 3)
        StartCoroutine(MuerteEventos3());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MuerteEventos1()
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(1);
    }

    IEnumerator MuerteEventos2()
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("Nivel 2");
    }

    IEnumerator MuerteEventos3()
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("Nivel 3");
    }
}
