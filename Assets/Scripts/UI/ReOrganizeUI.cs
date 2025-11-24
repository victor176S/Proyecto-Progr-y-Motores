using System.Collections;
using UnityEngine;

public class ReOrganizeUI : MonoBehaviour
{

    

    public static ReOrganizeUI instance;

    public int vecesQueSeMueve = 1;
    
    private float velocidad; //esto no hace nada, poner desde el editor
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        //SI NO SE PONE EL SCRIPT A UN OBJETO, ESTO DA ERROR
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //para cambiar a una posicion que no está, se tienen que hacer dos o más en sentido
    //contrario al del reloj (primero Der -> Top, luego Top -> Izq, despues Izq -> Bottom
    // y finalmente Bottom -> Der), si se hacen los 4, se queda donde está

    public IEnumerator UIFromRightToTop()
    {
        velocidad = 50/vecesQueSeMueve;

        //X = 550 Y = -90 con respecto a la pantalla?

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.LivesUI.transform.position += new Vector3 (-8, 0.5f, 0) *velocidad;

            GameManager.instance.porcentajeSaltoText.transform.position += new Vector3 (-15, 2.5f, 0) *velocidad;

            GameManager.instance.DashCharge.transform.position += new Vector3 (0, 5, 0) *velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        
    }

    public IEnumerator UIFromTopToRight()
    {

        velocidad = 50/vecesQueSeMueve;

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
        GameManager.instance.LivesUI.transform.position += new Vector3 (8, -2.5f, 0) *velocidad;

        GameManager.instance.porcentajeSaltoText.transform.position += new Vector3 (15, -2.5f, 0) *velocidad;

        GameManager.instance.DashCharge.transform.position += new Vector3 (0, -5, 0) *velocidad;

        yield return new WaitForSeconds (0.02f);

        }
    }

    public IEnumerator UIFromTopToLeft()
    {

        velocidad = 50/vecesQueSeMueve;

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
        GameManager.instance.LivesUI.transform.position += new Vector3 (-8, -0.5f, 0) *velocidad;

        GameManager.instance.porcentajeSaltoText.transform.position += new Vector3 (-1, -2.5f, 0) *velocidad;

        GameManager.instance.DashCharge.transform.position += new Vector3 (-17f, -5.5f, 0) *velocidad;

        yield return new WaitForSeconds (0.02f);

        }
    }

    public IEnumerator UIFromLeftToBottom()
    {

        velocidad = 50/vecesQueSeMueve;

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
        GameManager.instance.LivesUI.transform.position += new Vector3 (8, -10f, 0) *velocidad;

        GameManager.instance.porcentajeSaltoText.transform.position += new Vector3 (1, -6.5f, 0) *velocidad;

        GameManager.instance.DashCharge.transform.position += new Vector3 (15f, -5f, 0) *velocidad;

        yield return new WaitForSeconds (0.02f);

        }

    }

    public IEnumerator UIFromBottomToRight()
    {

        velocidad = 50/vecesQueSeMueve;

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
        GameManager.instance.LivesUI.transform.position += new Vector3 (8, 10f, 0) *velocidad;

        GameManager.instance.porcentajeSaltoText.transform.position += new Vector3 (15, 6.5f, 0) *velocidad;

        GameManager.instance.DashCharge.transform.position += new Vector3 (2f, 5.5f, 0) *velocidad;

        yield return new WaitForSeconds (0.02f);

        }

    }
}

