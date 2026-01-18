using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraEventTrigger : MonoBehaviour
{

    public static CameraEventTrigger instance;

    public List<GameObject> puntosDeControl;

    private int i;

    private GameObject camara;

    private bool autoScroll;

    private GameObject player;

    private GameObject canvasMegafono;

    private GameObject spawners;

    [Header("Jugador")]

    private bool enCaida;

    GameObject eventHandler;

    [SerializeField] private float speedY = -18f;

    void Awake()
    {
        instance = this;

        eventHandler = GameObject.Find("EventHandler");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (SceneManager.GetActiveScene().name == "Nivel 2")
        StartCoroutine(eventHandler.GetComponent<ReOrganizeUI>().UIFromRightToTop());

        camara = GameObject.Find("Main Camera");

        player = GameObject.Find("Player");

        canvasMegafono = GameObject.Find("CanvasMegafono");

        if (SceneManager.GetActiveScene().name == "Nivel 2" || SceneManager.GetActiveScene().name == "Nivel 3")
        spawners = canvasMegafono.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        

        if(enCaida)
        {

            Debug.Log("Jugador en caida");
        
                Vector3 pos = player.transform.position;

                pos.y += speedY * Time.deltaTime;

                player.transform.position = pos;

                if (player.GetComponent<PlayerMovement>().enSuelo)
                {
                    player.GetComponent<PlayerMovement>().rb.linearVelocity = Vector2.zero;
                    player.GetComponent<PlayerMovement>().rb.gravityScale = 4f;

                    enCaida = false;
                }

        }
    }
    //el objeto al que le afecta el trigger, tiene que tener un rigidbody
    //si quieres que su comportamiento original no cambie (en este caso, la camara)
    //pon gravedad 0 en el rigidbody
    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("cameraTrigger"))
        {
            Debug.Log("camara colision");

            i = puntosDeControl.IndexOf(other.gameObject);

            TriggerPuntoDeControl(i);
        }
            
    }

    public void TriggerPuntoDeControl(int i)
    {
         var nombreEscena = SceneManager.GetActiveScene().name;

        if (nombreEscena == "Nivel 1")
        {
            switch (i)
            {

            case 0:

                camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                camara.GetComponent<CameraAutoScroll2D>().enabled = false;

                camara.transform.position = new Vector3 (camara.transform.position.x, -545, camara.transform.position.z);
                
                StartCoroutine(MoverCamaraY(90, 1, 0, 13, true));

                StartCoroutine(Shake1(15, 1, 0.02f, 25));

                break;

            case 1:

                //CameraRotation.instance.target = 0f;

                break;

            case 2:

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 3:

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 4:

                puntosDeControl[i].gameObject.SetActive(false);

                break;
            
            default:

            break;
            }
        }
        
        if (nombreEscena == "Nivel 2")
        {
            switch (i)
            {

            case 0:

                camara = GameObject.Find("Main Camera");

                camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                camara.GetComponent<CameraAutoScroll2D>().enabled = false;
                
                StartCoroutine(MoverCamaraY(20, 1.5f, 0, 13, true));

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 1:

                camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                camara.GetComponent<CameraAutoScroll2D>().enabled = false;
                
                StartCoroutine(MoverCamaraY(40, -1.5f, 0, 13, true));

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 2:

                camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                camara.GetComponent<CameraAutoScroll2D>().enabled = false;
                
                StartCoroutine(MoverCamaraY(40, -1.5f, 0, 13, true));

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 3:

                    StartCoroutine(StartPlatformFall());

                    StartCoroutine(StartFall());

                    break;

            case 4:

                    StartCoroutine(InstantiateInFall(0, 0));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;
                
            case 5:

                    StartCoroutine(InstantiateInFall(1, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 6:

                    StartCoroutine(InstantiateInFall(0, 2));

                    StartCoroutine(InstantiateInFall(1, 3));

                    StartCoroutine(InstantiateInFall(1, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 7: //

                    StartCoroutine(InstantiateInFall(0, 0));

                    StartCoroutine(InstantiateInFall(1, 1));

                    StartCoroutine(InstantiateInFall(0, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 8:

                    StartCoroutine(InstantiateInFall(0, 0));

                    StartCoroutine(InstantiateInFall(1, 2));

                    StartCoroutine(InstantiateInFall(0, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 9:

                    StartCoroutine(InstantiateInFall(1, 1));

                    StartCoroutine(InstantiateInFall(1, 3));

                    puntosDeControl[i].gameObject.SetActive(false);


                    break;

            case 10:

                    StartCoroutine(InstantiateInFall(0, 0));

                    StartCoroutine(InstantiateInFall(0, 1));

                    StartCoroutine(InstantiateInFall(0, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 11:

                    StartCoroutine(InstantiateInFall(1, 1));

                    StartCoroutine(InstantiateInFall(1, 2));

                    StartCoroutine(InstantiateInFall(1, 3));

                    StartCoroutine(InstantiateInFall(1, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 12:

                    StartCoroutine(InstantiateInFall(1, 0));

                    StartCoroutine(InstantiateInFall(1, 1));

                    StartCoroutine(InstantiateInFall(1, 2));

                    StartCoroutine(InstantiateInFall(1, 3));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 13:

                    StartCoroutine(InstantiateInFall(1, 1));

                    StartCoroutine(InstantiateInFall(1, 2));

                    StartCoroutine(InstantiateInFall(1, 3));

                    StartCoroutine(InstantiateInFall(1, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 14:

                StartCoroutine(Shake1(1500, 0.2f, 0.02f, 0.01f));
                speedY = -18f;

                    break;


            case 15:

                    StartCoroutine(InstantiateInFall(0, 0));

                    StartCoroutine(InstantiateInFall(0, 1));

                    StartCoroutine(InstantiateInFall(0, 2));

                    StartCoroutine(InstantiateInFall(0, 3));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 16:

                    StartCoroutine(InstantiateInFall(1, 1));

                    StartCoroutine(InstantiateInFall(0, 2));

                    StartCoroutine(InstantiateInFall(1, 3));

                    StartCoroutine(InstantiateInFall(0, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 17:

                    StartCoroutine(InstantiateInFall(0, 0));

                    StartCoroutine(InstantiateInFall(1, 1));

                    StartCoroutine(InstantiateInFall(0, 2));

                    StartCoroutine(InstantiateInFall(1, 3));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 18:

                    StartCoroutine(InstantiateInFall(0, 1));

                    StartCoroutine(InstantiateInFall(0, 2));

                    StartCoroutine(InstantiateInFall(0, 3));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 19:

            

                var finalPosition = GameObject.Find("FinalPlace");

                var finalCanvas = GameObject.Find("SecondaryCanvasFinal");

                Debug.Log($"nombre del objeto {finalCanvas.gameObject.name}");

                player.gameObject.transform.position = finalPosition.transform.position;

                finalCanvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                var gameManager = GameObject.Find("GameManager");

                var datosPersistentes = GameObject.Find("DatosPersistentes");

                datosPersistentes.GetComponent<DatosPersistentes>().puntos = gameManager.GetComponent<GameManager>().puntos;

                finalCanvas.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = datosPersistentes.GetComponent<DatosPersistentes>().puntos.ToString();
                
                StartCoroutine(LoadSceneLate("Nivel 3", 18));

                    break;

            
            }
            

        }

        if (nombreEscena == "Nivel 3")
            {
                switch (i)
                {

                case 0:

                    camara.GetComponent<CameraAutoScroll2D>().scrollActivo = true;

                    enCaida = false;

                    camara.GetComponent<CameraRotation>().tiltAnimation = false;

                    camara.GetComponent<CameraRotation>().target = 0;

                    player.gameObject.GetComponent<PlayerMovement>().rb.constraints = RigidbodyConstraints2D.None;

                    player.gameObject.GetComponent<PlayerMovement>().rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;
                    
                case 1:

                    GameObject fuegosScroll = GameObject.Find("FuegosScroll");

                    StartCoroutine(MoveFire(true, fuegosScroll));

                    fuegosScroll.transform.localEulerAngles = new Vector3(0, 0, 0);

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 2:

                    camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                    camara.GetComponent<CameraAutoScroll2D>().enabled = false;
                
                    StartCoroutine(MoverCamaraY(90, -1.5f, 0, 17, false));

                    StartCoroutine(AdjustCamera());
                    
                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 3:

                    GameObject fuegosScroll1 = GameObject.Find("FuegosScroll");

                    GameObject PlatFormLift = GameObject.Find("PlataformaLift");

                    StartCoroutine(MoveFire(false, fuegosScroll1));

                    StartCoroutine(PlatformUP(PlatFormLift, 85, 0.0001f));

                    camara.GetComponent<CameraAutoScroll2D>().yOffset = 15;

                    StartCoroutine(eventHandler.GetComponent<ArrowsAnim>().BottomToTopArrowsAnim());

                    StartCoroutine(eventHandler.GetComponent<ReOrganizeUI>().UIFromBottomToRight());

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 4:

                    camara.GetComponent<CameraAutoScroll2D>().enabled = true;

                    camara.GetComponent<CameraAutoScroll2D>().scrollActivo = true;

                    camara.GetComponent<CameraAutoScroll2D>().speedX = 0;

                    StartCoroutine(CheckHeight(-565));

                    StartCoroutine(Shake1(1300, 0.2f, 0.02f, 0.01f));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 5:

                    StartCoroutine(InstantiateInFall(3, 1));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 6:

                    StartCoroutine(InstantiateInFall(5, 1));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 7:

                    StartCoroutine(InstantiateInFall(4, 0));

                    StartCoroutine(InstantiateInFall(4, 1));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;
                
                case 8:

                    StartCoroutine(InstantiateInFall(5, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 9:

                    StartCoroutine(InstantiateInFall(4, 0));

                    StartCoroutine(InstantiateInFall(4, 2));

                    StartCoroutine(InstantiateInFall(4, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 10:

                    StartCoroutine(InstantiateInFall(3, 1));

                    StartCoroutine(InstantiateInFall(3, 3));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 11:

                    StartCoroutine(InstantiateInFall(4, 0));

                    StartCoroutine(InstantiateInFall(4, 2));

                    StartCoroutine(InstantiateInFall(4, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 12:

                    StartCoroutine(InstantiateInFall(4, 1));

                    StartCoroutine(InstantiateInFall(4, 3));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 13:

                    StartCoroutine(InstantiateInFall(5, 0));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 14:

                    StartCoroutine(InstantiateInFall(5, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 15:

                    StartCoroutine(InstantiateInFall(3, 0));

                    StartCoroutine(InstantiateInFall(3, 1));

                    StartCoroutine(InstantiateInFall(3, 3));

                    StartCoroutine(InstantiateInFall(3, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 16:

                    camara.GetComponent<CameraAutoScroll2D>().yOffset = 0;

                    GameObject platform = GameObject.Find("PlataformaLift");

                    StartCoroutine(FromUpToNormal());

                    platform.gameObject.transform.GetChild(12).gameObject.SetActive(false);

                    break;

                case 17:

                    GameObject PlatFormLift1 = GameObject.Find("PlataformaLift1");

                    StartCoroutine(PlatformUP(PlatFormLift1, 120, 0.0001f));

                    camara.GetComponent<CameraAutoScroll2D>().yOffset = 15;

                    StartCoroutine(eventHandler.GetComponent<ArrowsAnim>().BottomToTopArrowsAnim());

                    camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                    StartCoroutine(Shake1(2000, 0.2f, 0.02f, 1f));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 18:

                    StartCoroutine(InstantiateInFall(5, 1));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 19:

                    StartCoroutine(InstantiateInFall(4, 0));

                    StartCoroutine(InstantiateInFall(4, 1));

                    StartCoroutine(InstantiateInFall(4, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 20:

                    StartCoroutine(InstantiateInFall(3, 2));

                    StartCoroutine(InstantiateInFall(3, 3));

                    StartCoroutine(InstantiateInFall(3, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 21:

                    StartCoroutine(InstantiateInFall(5, 0));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 22:

                    StartCoroutine(InstantiateInFall(5, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 23:

                    StartCoroutine(InstantiateInFall(3, 0));

                    StartCoroutine(InstantiateInFall(3, 2));

                    StartCoroutine(InstantiateInFall(3, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 24:

                    StartCoroutine(InstantiateInFall(4, 1));

                    StartCoroutine(InstantiateInFall(4, 3));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 25:

                    StartCoroutine(InstantiateInFall(5, 1));
                    
                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 26:

                    StartCoroutine(InstantiateInFall(4, 0));

                    StartCoroutine(InstantiateInFall(4, 1));

                    StartCoroutine(InstantiateInFall(4, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 27:

                    StartCoroutine(InstantiateInFall(4, 2));

                    StartCoroutine(InstantiateInFall(4, 3));

                    StartCoroutine(InstantiateInFall(4, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 28:

                    StartCoroutine(InstantiateInFall(4, 0));

                    StartCoroutine(InstantiateInFall(4, 1));

                    StartCoroutine(InstantiateInFall(4, 2));

                    StartCoroutine(InstantiateInFall(4, 3));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 29:

                    StartCoroutine(InstantiateInFall(4, 0));

                    StartCoroutine(InstantiateInFall(4, 1));

                    StartCoroutine(InstantiateInFall(4, 2));

                    StartCoroutine(InstantiateInFall(4, 4));

                    puntosDeControl[i].gameObject.SetActive(false);


                    break;

                case 30:

                    StartCoroutine(InstantiateInFall(4, 0));

                    StartCoroutine(InstantiateInFall(4, 1));

                    StartCoroutine(InstantiateInFall(4, 3));

                    StartCoroutine(InstantiateInFall(4, 4));
                    
                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 31:

                    StartCoroutine(InstantiateInFall(4, 0));

                    StartCoroutine(InstantiateInFall(4, 2));

                    StartCoroutine(InstantiateInFall(4, 3));

                    StartCoroutine(InstantiateInFall(4, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 32:

                    StartCoroutine(InstantiateInFall(4, 1));

                    StartCoroutine(InstantiateInFall(4, 2));

                    StartCoroutine(InstantiateInFall(4, 3));

                    StartCoroutine(InstantiateInFall(4, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 33:

                    StartCoroutine(InstantiateInFall(5, 0));

                    StartCoroutine(InstantiateInFall(5, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 34:

                    StartCoroutine(InstantiateInFall(5, 1));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 35:

                    StartCoroutine(InstantiateInFall(3, 0));

                    StartCoroutine(InstantiateInFall(3, 2));

                    StartCoroutine(InstantiateInFall(3, 3));

                    StartCoroutine(InstantiateInFall(3, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 36:

                    StartCoroutine(InstantiateInFall(4, 1));

                    StartCoroutine(InstantiateInFall(4, 2));

                    StartCoroutine(InstantiateInFall(4, 3));

                    StartCoroutine(InstantiateInFall(4, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 37:

                    StartCoroutine(InstantiateInFall(5, 0));

                    StartCoroutine(InstantiateInFall(5, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

                case 38:

                var finalCanvas = GameObject.Find("SecondaryCanvasFinal");

                Debug.Log($"nombre del objeto {finalCanvas.gameObject.name}");

                finalCanvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                var gameManager = GameObject.Find("GameManager");

                var datosPersistentes = GameObject.Find("DatosPersistentes");

                datosPersistentes.GetComponent<DatosPersistentes>().puntos = gameManager.GetComponent<GameManager>().puntos;

                finalCanvas.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = datosPersistentes.GetComponent<DatosPersistentes>().puntos.ToString();

                StartCoroutine(LoadSceneLate("Menu", 28));

                    break;
                
                }


            }

    IEnumerator FromUpToNormal()
    {
        yield return new WaitForSeconds(2);

        camara.GetComponent<CameraAutoScroll2D>().scrollActivo = true;

        camara.GetComponent<CameraAutoScroll2D>().speedX = 10;    
    }

    IEnumerator PlatformUP(GameObject platform, float altura, float secsPerMove)
    {

        yield return new WaitForSeconds (2f);

        for (int i = 0; i < altura * 50; i++)
        {

            yield return new WaitForSecondsRealtime(secsPerMove);

            platform.transform.position += new Vector3(0, 0.2f, 0);

        }
            
    }

    IEnumerator CheckHeight(float posicion)
    {
        for (int i = 0; i < 100; i++)
        {
           yield return new WaitForSeconds(0.2f);

           if (player.transform.position.y < posicion)
            {
                SceneManager.LoadScene("EscenaMuerte4");    
            }     
        }
    }

    IEnumerator LoadSceneLate(string scene, float wait)
    {
        yield return new WaitForSecondsRealtime (wait);

        SceneManager.LoadScene(scene);
    } 

    IEnumerator MoverCamaraY(float cantidad, float multiplicador, float retardo, float velocidad, bool devolverScroll)
    {
        for (int i = 0; i < cantidad * 15; i++)
        {
            yield return new WaitForSecondsRealtime(0.018f);

            camara.transform.position -= new Vector3 (0, 0.055f * multiplicador, 0);
        }

        yield return new WaitForSeconds(retardo);

        camara.GetComponent<CameraAutoScroll2D>().enabled = true;

        if (devolverScroll)
        {
            camara.GetComponent<CameraAutoScroll2D>().scrollActivo = true;

            camara.GetComponent<CameraAutoScroll2D>().speedX = velocidad;
        }

        else
        {
            camara.GetComponent<CameraAutoScroll2D>().scrollActivo = true;

            yield return new WaitForSeconds(0.1f);

            camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;
            
        }

        

    }

    IEnumerator AdjustCamera()
    {

        yield return new WaitForSeconds(21f);

        for (int i = 0; i < 15; i++)
        {

            yield return new WaitForSeconds(0.06f);

            camara.transform.position += new Vector3(1, 0, 0);

            camara.GetComponent<Camera>().fieldOfView -= 1f;

        }

    }

    IEnumerator Shake1(int timesShake, float magnitude, float shakeSpeed, float shakeDelay)
    {
        Debug.Log("entrada Shake1");

        yield return new WaitForSecondsRealtime(shakeDelay);

        Debug.Log("accion Shake1");
        
        StartCoroutine(camara.GetComponent<CameraShake>().ShakeLogic(timesShake, magnitude, shakeSpeed));
    }

    IEnumerator InstantiateInFall(int objeto, int lugar)
    {
        
        if (objeto == 0)
            {

                var caja = GameObject.Find("cajadamage");
                
                var caja1 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(0, 5, 0), quaternion.identity);

                var caja2 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(3, 5, 0), quaternion.identity);

                var caja3 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(-3, 5, 0), quaternion.identity);

                var caja4 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(3, 0, 0), quaternion.identity);

                var caja5 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(-3, 0, 0), quaternion.identity);

                caja1.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja2.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja3.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja4.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja5.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                switch (lugar)
                {
                case 0:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(true, false, false, false, false));

                    break;

                case 1:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, true, false, false, false));

                    break;

                case 2:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, true, false, false));

                    break;

                case 3:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, true, false));

                    break;

                case 4:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, false, true));

                    break;
                }

                

                yield return new WaitForSeconds (10f);

                Destroy(caja1);

                Destroy(caja2);

                Destroy(caja3);

                Destroy(caja4);

                Destroy(caja5);

            }
        
        if (objeto == 1)
            {
                var vigas = GameObject.Find("Vigas");
                
                var vigas1 = Instantiate(vigas, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90), quaternion.identity);

                vigas1.GetComponent<Rigidbody2D>().AddTorque(20, ForceMode2D.Impulse);

                switch (lugar)
                {
                case 0:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(true, false, false, false, false));

                    break;

                case 1:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, true, false, false, false));

                    break;

                case 2:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, true, false, false));

                    break;

                case 3:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, true, false));

                    break;

                case 4:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, false, true));

                    break;
                }

                yield return new WaitForSeconds (10f);

                Destroy(vigas1);
            }

        if (objeto == 2)
            {
                var cristal = GameObject.Find("Cristal");
                
                var cristal1 = Instantiate(cristal, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90), quaternion.identity);

                cristal1.GetComponent<Rigidbody2D>().AddTorque(100, ForceMode2D.Impulse);

                switch (lugar)
                {
                case 0:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(true, false, false, false, false));

                    break;

                case 1:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, true, false, false, false));

                    break;

                case 2:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, true, false, false));

                    break;

                case 3:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, true, false));

                    break;

                case 4:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, false, true));

                    break;
                }

                yield return new WaitForSeconds (10f);

                Destroy(cristal1);
            }

        if (objeto == 3)
            {
                var caja = GameObject.Find("cajadamageRebote");
                
                var caja1 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(0, 5, 0), quaternion.identity);

                var caja2 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(3, 5, 0), quaternion.identity);

                var caja3 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(-3, 5, 0), quaternion.identity);

                var caja4 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(3, 0, 0), quaternion.identity);

                var caja5 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(-3, 0, 0), quaternion.identity);

                caja1.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja2.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja3.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja4.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja5.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                switch (lugar)
                {
                case 0:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(true, false, false, false, false));

                    break;

                case 1:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, true, false, false, false));

                    break;

                case 2:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, true, false, false));

                    break;

                case 3:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, true, false));

                    break;

                case 4:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, false, true));

                    break;
                }

                

                yield return new WaitForSeconds (10f);

                Destroy(caja1);

                Destroy(caja2);

                Destroy(caja3);

                Destroy(caja4);

                Destroy(caja5);
            }

        if (objeto == 4)
            {
                var vigas = GameObject.Find("VigasRebote");
                
                var vigas1 = Instantiate(vigas, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90), quaternion.identity);

                vigas1.GetComponent<Rigidbody2D>().AddTorque(20, ForceMode2D.Impulse);

                switch (lugar)
                {
                case 0:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(true, false, false, false, false));

                    break;

                case 1:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, true, false, false, false));

                    break;

                case 2:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, true, false, false));

                    break;

                case 3:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, true, false));

                    break;

                case 4:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, false, true));

                    break;
                }

                yield return new WaitForSeconds (10f);

                Destroy(vigas1);
            }

        if (objeto == 5)
            {
               var cristal = GameObject.Find("CristalRebote");
                
                var cristal1 = Instantiate(cristal, spawners.transform.GetChild(lugar + 1).transform.position - new Vector3 (0,0,90), quaternion.identity);

                cristal1.GetComponent<Rigidbody2D>().AddTorque(100, ForceMode2D.Impulse);

                switch (lugar)
                {
                case 0:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(true, false, false, false, false));

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, true, false, false, false));

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, true, false, false));

                    break;

                case 1:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, true, false));

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, true, false, false, false));

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, true, false, false));

                    break;

                case 2:

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, true, false, false));

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, true, false));

                    StartCoroutine(eventHandler.GetComponent<WarningsAnimation>().WarningAnimationUP(false, false, false, false, true));

                    break;
                }

                yield return new WaitForSeconds (10f);

                Destroy(cristal1); 
            }
    }

    IEnumerator StartFall()
    {

        yield return new WaitForSeconds(1f);

            StartCoroutine(FovFallAdapt());

            player.GetComponent<PlayerMovement>().enSuelo = false;

            player.GetComponent<AnimationsPlayer>().animator.SetTrigger("CaidaInesperada");

                //StartCoroutine(AnimationsPlayer.instance.TriggerRecompostura());

            gameObject.GetComponent<CameraMovement>().Movement(2);
                //ESTO SI CAMBIA LA GRAVEDAD

            player.GetComponent<PlayerMovement>().rb.linearVelocity = Vector2.zero;
            player.GetComponent<PlayerMovement>().rb.gravityScale = 0f;
            player.GetComponent<PlayerMovement>().rb.constraints = RigidbodyConstraints2D.FreezePositionY;

            gameObject.GetComponent<CameraRotation>().tiltAnimation = true;

            enCaida = true;

            StartCoroutine(eventHandler.GetComponent<ArrowsAnim>().TopToBottomArrowsAnim());

            StartCoroutine(player.GetComponent<Sounds>().PlaySound(0,2)); 

            puntosDeControl[i].gameObject.SetActive(false);

            


            
        }

    IEnumerator FovFallAdapt()
        {

            camara.GetComponent<CameraAutoScroll2D>().yOffset = 10;

            for (int i = 0; i < 20; i++)
            {
                camara.GetComponent<Camera>().fieldOfView -= 1f;

                yield return new WaitForSeconds(0.03f);
            }
        }
    
    IEnumerator StartPlatformFall()
        {
            int rotation = 4;

            camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

            var platformFall = GameObject.Find("PlatformFall");

            for (int i = 0; i < 800; i++)
            {
                platformFall.gameObject.transform.position -= new Vector3 (0, 5, 0);

                platformFall.gameObject.transform.rotation = Quaternion.Euler (0, 0, rotation);

                rotation += 4;

                yield return new WaitForSecondsRealtime(0.1f);
            }
        }


    IEnumerator MoveFire(bool direccion, GameObject fuegosScroll)
    {
            
        if (direccion)
        {
            for(int i = 0; i < 20; i++)
            {
                fuegosScroll.transform.localPosition += new Vector3(1.1f, 0, 0);

                yield return new WaitForSeconds(0.05f);

            }
        }

        else
        {
           for(int i = 0; i < 20; i++)
            {
                fuegosScroll.transform.localPosition += new Vector3(-1.1f, 0, 0);

                yield return new WaitForSeconds(0.05f);

            }     
        }

    }
    }
}
