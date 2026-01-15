using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eventos : MonoBehaviour
{
    public GameObject simpleDialogs;
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

    public List<GameObject> spawnPoints;

    private int randomAnterior;
    private bool activateNextCorrutine;

    

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        

          if (SceneManager.GetActiveScene().name == "Nivel 1")
        {

            sprispriteMegafonoBase = megafono.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;

            megafono.transform.position += new Vector3(0, 100, 0);

            StartCoroutine(EventosNivel1());
        }

        if (SceneManager.GetActiveScene().name == "Nivel 2")
        {
            StartCoroutine(EventosNìvel2());
        }
    }

    #region Eventos nivel 2

    IEnumerator EventosNìvel2()
    {
        StartCoroutine(Shake1(1000, 0.02f, 1));

        RandomInstantiate();

        //activateNextCorrutine = false;

        StartCoroutine(DialogosYCamara());

        /*if (activateNextCorrutine)
        {
            activateNextCorrutine = false;
        }

        if (activateNextCorrutine)
        {
            
        }*/

        yield return new WaitForSeconds(22f);

        Debug.Log("segundo shake");

        StartCoroutine(Shake1(160, 0.01f, 0));

        StartCoroutine(CaidaDialogos());

        StartCoroutine(CameraMovementAndAdaptation());

        StartCoroutine(CameraScrollStart());

        yield return new WaitForSeconds(17f);


    }

    IEnumerator CameraMovementAndAdaptation()
    {
        StartCoroutine(CameraFOVChange());

        camaras[0].GetComponent<CameraRotation>().tiltAnimation = true;

        yield return new WaitForSecondsRealtime(17f);

        camaras[0].GetComponent<CameraRotation>().tiltAnimation = false;

        camaras[0].GetComponent<CameraRotation>().target = 0;

        //camaras[0].transform.rotation = Quaternion.Euler(0,0,0);

       
        

        
    }

    IEnumerator CaidaDialogos()
    {
        float rotation = 0;

        for (int i = 0; i < 1000; i++)
        {
            simpleDialogs.gameObject.transform.position -= new Vector3 (0, 8, 0);
            simpleDialogs.gameObject.transform.rotation = Quaternion.Euler (0, 0, rotation);

            rotation += 5f; 

            yield return new WaitForSeconds(0.02f);
        }
        
    }

    IEnumerator DialogosYCamara()
    {
        yield return new WaitForSeconds(12f);

        simpleDialogs = GameObject.Find("SimpleDialogs");
        
        StartCoroutine(DialogosSimples("Las instalaciones están teniendo varios fallos, se recomienda la evacuacion inmediata"));

        activateNextCorrutine = true;
    }

    IEnumerator DialogosSimples(string dialogo)
    {

        simpleDialogs.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogo;

        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.02f);

            simpleDialogs.gameObject.transform.position -= new Vector3(0,5,0);
        }

        yield return new WaitForSeconds (3f);

        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.02f);

            simpleDialogs.gameObject.transform.position += new Vector3(0,5,0);
        }

        //simpleDialogs.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }

    void RandomInstantiate()
    {
        var spawnPoint1 = GameObject.Find("SpawnPoint1");

        Debug.Log($"nombre spawn: {spawnPoint1.gameObject.name}");

        var spawnPoint2 = GameObject.Find("SpawnPoint2");

        var spawnPoint3 = GameObject.Find("SpawnPoint3");

        spawnPoints.Add(spawnPoint1);

        spawnPoints.Add(spawnPoint2);

        spawnPoints.Add(spawnPoint3);

        var caja = GameObject.Find("caja");
        
        StartCoroutine(RandomizedInstantiate(caja));

       
    }

    IEnumerator RandomizedInstantiate(GameObject caja)
    {
        for (int i = 0; i < 20; i++)
        {
            var random = UnityEngine.Random.Range(0,3);

            while (randomAnterior == random)
            {
               random = UnityEngine.Random.Range(0,3);
            }

            var cajaRandom = Instantiate(caja, spawnPoints[random].transform.position, quaternion.identity);

            cajaRandom.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.2f);

            randomAnterior = random;

        }

        GameObject vigas = GameObject.Find("Vigas"); 

        GameObject vigaRandom = Instantiate(vigas, spawnPoints[1].transform.position, quaternion.identity);

        vigaRandom.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

        yield return new WaitForSeconds(7f);

        camaras[1].gameObject.SetActive(false);

        camaras[0].gameObject.SetActive(true);
    }

    #endregion

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

    IEnumerator Shake1(int veces, float velocidad, int camara)
    {
        yield return new WaitForSeconds (0.001f);
        
        StartCoroutine(camaras[camara].GetComponent<CameraShake>().ShakeLogic(veces, 0.2f, velocidad));
    }
}
