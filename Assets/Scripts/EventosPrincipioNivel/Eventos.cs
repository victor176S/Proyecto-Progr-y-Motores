using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eventos : MonoBehaviour
{
    public static Eventos instance;

    [Header("Asignacion objetos")]

    public GameObject esteObjeto;
    public GameObject camara;

    public GameObject canvasDialogos;

    public GameObject player;

    public GameObject megafono; //el megafono en si no, el contenedor del megafono, para evitar lios con las rotaciones

    [Header("Variables eventos de movimiento")]

    private bool moverMegafono, arriba, abajo, izq, derecha;

    public float cantidadMovimiento;

    public float tiempoMovimiento;

    public float velocidadMovimiento;

    [Header ("alphachange")]

    public float contador;
    public float tiempo;
    public bool fade;
    public float delay;
    public bool hasChildren;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Nivel 1")
        {
            StartCoroutine(EventosNivel1());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(AlphaChangeV2());
        MovimientoLogic();

    }

    public IEnumerator EventosNivel1()
    {
        moverMegafono = true;

        arriba = true;

        yield return new WaitForSeconds(1f); // siempre tiene que ser un segundo para cuadrar con el movimiento del update
       
        moverMegafono = false;

        arriba = false;

        megafono.transform.GetComponentInChildren<AnimacionesMegafono>().activeAnim = true;

        yield return new WaitForSeconds(7f);

        camara.gameObject.GetComponent<Camera>().fieldOfView = 130;



    }

    private void MovimientoLogic()
    {
        if (moverMegafono)
        {
            if (arriba)

            megafono.transform.Translate(Vector2.down * cantidadMovimiento * velocidadMovimiento * tiempoMovimiento * Time.deltaTime);
        }
    }

    IEnumerator AlphaChangeV2()
    {
        yield return new WaitForSeconds(delay);
        
        if (contador <= tiempo)
        {
            contador += Time.deltaTime * 6;

            if (fade)
            {
                canvasDialogos.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f - (1/tiempo * Time.deltaTime * 6));

                if (hasChildren)
                {
                    canvasDialogos.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color += new Color (0f,0f,0f, 0f - (1/tiempo * Time.deltaTime * 6));

                }
            }

        }

        if (contador > tiempo)
        {
            contador = tiempo; 
        }
    }
}
