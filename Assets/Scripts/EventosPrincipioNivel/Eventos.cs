using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eventos : MonoBehaviour
{
    public static Eventos instance;

    [Header("Asignacion objetos")]

    public GameObject esteObjeto;
    private GameObject camara = GameManager.instance.camara;

    public GameObject canvasDialogos;

    private GameObject player = GameManager.instance.player;

    public GameObject megafono; //el megafono en si no, el contenedor del megafono, para evitar lios con las rotaciones

    [Header("Variables eventos de movimiento")]

    private bool moverMegafono, arriba, abajo, izq, derecha;

    public float cantidadMovimiento;

    public float tiempoMovimiento;

    public float velocidadMovimiento;


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

        yield return new WaitForSeconds(3f);

        canvasDialogos.GetComponent<AlphaChangerPanelImage>().AlphaChange(3, 3);
        
        yield return new WaitForSeconds(2f);

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
}
