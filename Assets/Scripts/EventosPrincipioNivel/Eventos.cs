using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eventos : MonoBehaviour
{
    public static Eventos instance;

    private Sprite sprispriteMegafonoBase;

    [Header("Asignacion objetos")]

    public GameObject esteObjeto;
    public List<GameObject> camaras;

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

    [Header ("camera FOV change values")]

    [SerializeField] private float fovObjetivo;

    public float addFov;

    public float timeFOVChange;

    [Header ("camera move values")]

    public float distance;

    public float tiempoCameraMove;

    private int i;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        sprispriteMegafonoBase = megafono.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;

        megafono.transform.position += new Vector3(0, 100, 0);

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

        //cambiar
        while(i < tiempo * 60)
        {
            camaras[1].gameObject.transform.Translate(Vector3.right * Time.deltaTime * 5 * distance / tiempo);
            i++;
            yield return new WaitForSeconds(0.0167f);
        }
    
        i = 0;
        
        //yield return new WaitForSeconds(3f);

        camaras[1].gameObject.SetActive(false);

        camaras[0].gameObject.SetActive(true);

        megafono.transform.position -= new Vector3(0, 40, 0);

        moverMegafono = true;

        abajo = true;

        yield return new WaitForSeconds(1f); // siempre tiene que ser un segundo para cuadrar con el movimiento del update
       
        moverMegafono = false;

        abajo = false;

        megafono.transform.GetComponentInChildren<AnimacionesMegafono>().activeAnim = true;

        yield return new WaitForSeconds(9f);

        megafono.transform.GetComponentInChildren<AnimacionesMegafono>().activeAnim = false;

        megafono.transform.GetComponentInChildren<SpriteRenderer>().sprite = sprispriteMegafonoBase;

        moverMegafono = true;

        arriba = true;

        yield return new WaitForSeconds(2f);

        moverMegafono = false;

        arriba = false;

        StartCoroutine(CameraFOVChange());

        StartCoroutine(CameraScrollStart());

    }

    private void MovimientoLogic()
    {
        if (moverMegafono)
        {
            if (abajo)
            {
                megafono.transform.Translate(Vector2.down * cantidadMovimiento * velocidadMovimiento * tiempoMovimiento * Time.deltaTime);
            }

            if (arriba)
            {
                megafono.transform.Translate(Vector2.up * cantidadMovimiento * velocidadMovimiento * tiempoMovimiento * Time.deltaTime);
            }

            if (izq)
            {
                megafono.transform.Translate(Vector2.left * cantidadMovimiento * velocidadMovimiento * tiempoMovimiento * Time.deltaTime);
            }
            
            if (derecha)
            {
                megafono.transform.Translate(Vector2.right * cantidadMovimiento * velocidadMovimiento * tiempoMovimiento * Time.deltaTime);
            }

        }
    }

    IEnumerator CameraFOVChange()
    {
        var originalFov = camaras[0].gameObject.GetComponent<Camera>().fieldOfView;

        if (fovObjetivo > originalFov)
        {
            while (camaras[0].gameObject.GetComponent<Camera>().fieldOfView < fovObjetivo)
            {
                yield return new WaitForSeconds(0.01f);

                camaras[0].gameObject.GetComponent<Camera>().fieldOfView += 0.5f;

            }
        }

        if (fovObjetivo < originalFov)
        {
            while (camaras[0].gameObject.GetComponent<Camera>().fieldOfView < fovObjetivo)
            {
                yield return new WaitForSeconds(0.01f);

                camaras[0].gameObject.GetComponent<Camera>().fieldOfView -= 0.5f;

            }
        }

        

        /*for (int i = 0; i < addFov; i++)
        {
            yield return new WaitForSeconds(0.05f);

            camaras[0].gameObject.GetComponent<Camera>().fieldOfView += (addFov / 60) / timeFOVChange ;
        }*/
    }

    IEnumerator CameraScrollStart()
    {
        yield return new WaitForSeconds(1);

        camaras[0].gameObject.GetComponent<CameraAutoScroll2D>().scrollActivo = true;
    }
}
