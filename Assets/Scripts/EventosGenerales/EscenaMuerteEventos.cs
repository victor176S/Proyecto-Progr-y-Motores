using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaMuerteEventos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MuerteEventos1());
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
}
